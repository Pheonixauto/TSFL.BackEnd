using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSFL.Application.Abstractions;
using TSFL.Application.IRepository.ICardGroupCardsRepository;
using TSFL.Application.IRepository.ICardRepository;
using TSFL.Application.IRepository.IGroupCardRepository;
using TSFL.Application.IRepository.IMemberRepository;
using TSFL.Persistance.Concreates;
using TSFL.Persistance.Context;
using TSFL.Persistance.Repository.CardGroupCardsRepository;
using TSFL.Persistance.Repository.CardRepository;
using TSFL.Persistance.Repository.GroupCardRepository;
using TSFL.Persistance.Repository.MemberRepository;

namespace TSFL.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection IAddServicePersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TSFLDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings"),
                        b => b.MigrationsAssembly(typeof(TSFLDbContext).Assembly.FullName)), ServiceLifetime.Scoped);

            services.AddSingleton<ICardService, CardService>();
            services.AddScoped<ICardGroupCardsReadRepository, CardGroupCardsReadRepository>();
            services.AddScoped<ICardGroupCardsWriteRepository, CardGroupCardsWriteRepository>();

            services.AddScoped<ICardReadRepository, CardReadRepository>();
            services.AddScoped<ICardWriteRepository, CardWriteRepository>();

            services.AddScoped<IGroupCardReadRepository, GroupCardReadRepository>();
            services.AddScoped<IGroupCardWriteRepository, GroupCardWriteRepository>();

            services.AddScoped<IMemberReadRepository, MemberReadRepository>();
            services.AddScoped<IMemberWriteRepository, MemberWriteRepository>();

            return services;
        }

        //public static void AddServicePersistance(this IServiceCollection services)
        //{
        //    //services.AddDbContext<TSFLDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings"),
        //    //            b => b.MigrationsAssembly(typeof(TSFLDbContext).Assembly.FullName)), ServiceLifetime.Transient);

        //    //services.AddDbContext<TSFLDbContext>(options => options.UseSqlServer(Configurations.GetConnectionString));

        //    services.AddSingleton<ICardService, CardService>();
        //}
    }
}
