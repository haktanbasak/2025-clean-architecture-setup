using CleanArchitecture_2025.Domain.Employees;
using CleanArchitecture_2025.Infrastructure.Context;
using CleanArchitecture_2025.Infrastructure.Repository;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure
{
    public static class InfrastructureRegistrar
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("SqlServer") ?? "";
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

            // Scrutor paketi ile yukarıdaki satırın yerine geçer dependency injection işlemi
            services.Scan(scan => scan
                .FromAssemblies(typeof(InfrastructureRegistrar).Assembly)
                .AddClasses(publicOnly: false)
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
             );

            return services;
        }
    }
}
