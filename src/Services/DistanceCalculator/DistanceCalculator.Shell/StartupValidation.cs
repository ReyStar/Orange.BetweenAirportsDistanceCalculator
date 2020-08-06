﻿using System;
using System.Collections.Generic;
using DistanceCalculator.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace DistanceCalculator.Shell
{
    public class StartupValidation : IStartupFilter
    {
        private readonly IEnumerable<IHealthCheckValidator> _validators;

        public StartupValidation(IEnumerable<IHealthCheckValidator> validators)
        {
            _validators = validators;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            foreach (var validator in _validators)
            {
                validator.EnsureValidationAsync()
                         .GetAwaiter()
                         .GetResult();
            }

            return next;
        }
    }
}