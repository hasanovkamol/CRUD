using CRUD.Application.Presistencs;
using CRUD.Infrasture.Context;
using CRUD.Infrasture.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRUD.Infrasture
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CustomDbContext>(options =>
                options.UseOracle(configuration.GetConnectionString("CusConnectionString")
                //,builder => { builder.CommandTimeout(5); }
                ));

            services.AddScoped(typeof(IRepository<>), typeof(Repositroy<>));
            
            return services;
        }
    }
}
