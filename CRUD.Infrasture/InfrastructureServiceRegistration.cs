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
                options.UseSqlServer(configuration.GetConnectionString("CusConnectionString"),
                builder => { builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); }));

            services.AddScoped(typeof(IRepository<>), typeof(Repositroy<>));
            
            return services;
        }
    }
}
