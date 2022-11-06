﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WinWin.Persistence.DataBaseContext;
using WinWin.Persistence.GenericDapperRepositories;
using WinWin.Persistence.GenericRepositories;
using WinWin.Persistence.IGenericDapperRepositories;
using WinWin.Persistence.IGenericRepositories;
using WinWin.Service.AutoMapperProfiles;
using WinWin.Service.IService.ICardServices;
using WinWin.Service.IService.IContentCardServices;
using WinWin.Service.Service.CardServices;
using WinWin.Service.Service.ContentCardServices;

namespace WinWin.Infrastructure.Configuration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection IAddServicePersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WinWinDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("WinWinConnectionString"),
                        b => b.MigrationsAssembly(typeof(WinWinDBContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            return services;
        }

        public static IServiceCollection IAddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IGenericDapperRepository, GenericDapperRepository>();

            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IContentCardService, ContentCardService>();

            return services;
        }
    }
}