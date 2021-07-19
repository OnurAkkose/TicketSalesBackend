﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.Utilites.IoC;

namespace TicketSales.Core.Extensions
{
    public static class ServiceConnectionExtensions

    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection
            , ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
