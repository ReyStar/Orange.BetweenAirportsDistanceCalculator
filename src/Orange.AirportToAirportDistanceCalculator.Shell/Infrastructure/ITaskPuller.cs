﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.AirportToAirportDistanceCalculator.Shell.Infrastructure
{
    public interface ITaskPuller
    {
        Task<Func<CancellationToken, Task>> GetTaskAsync(CancellationToken cancellationToken);
    }
}
