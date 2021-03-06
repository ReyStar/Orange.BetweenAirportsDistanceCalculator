﻿using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Orange.AirportToAirportDistanceCalculator.Common;

namespace Orange.AirportToAirportDistanceCalculator.Shell.Infrastructure
{
    public class BackgroundTaskProvider : IBackgroundTaskProvider, ITaskPuller
    {
        private readonly ConcurrentQueue<Func<CancellationToken, Task>> _workItems;
        private readonly SemaphoreSlim _signal;

        public BackgroundTaskProvider()
        {
            _workItems = new ConcurrentQueue<Func<CancellationToken, Task>>();
            _signal = new SemaphoreSlim(0);
        }

        public void AddBackgroundTask(Func<CancellationToken, Task> workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            _workItems.Enqueue(workItem);
            _signal.Release();
        }

        public async Task<Func<CancellationToken, Task>> GetTaskAsync(CancellationToken cancellationToken)
        {
            await _signal.WaitAsync(cancellationToken);
            _workItems.TryDequeue(out var workItem);

            return workItem;
        }
    }
}