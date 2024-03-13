﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework
{
    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services
                .AddDbContext<DatabaseContext>(o => o
                    .UseLazyLoadingProxies() // lazy loading
                    .UseSqlServer(connectionString));
            return services;
        }
    }
}