﻿using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Orange.AirportToAirportDistanceCalculator.Shell.Configuration
{
    static class AutoMapperExtensions
    {
        public static void RegisterAutoMapper(this IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(IMapper), sp =>
            {
                var profiles = sp.GetRequiredService<IEnumerable<Profile>>();

                var configuration = new MapperConfiguration(cfg => { cfg.AddProfiles(profiles); });

                var mapper = configuration.CreateMapper();

                return mapper;

            }, ServiceLifetime.Singleton));
        }
    }
}
