using CarRental.Application.Interfaces;
using CarRental.Application.Services;
using CarRental.Domain.Interfaces;
using CarRental.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarRental.Infra.Data;
using CarRental.Application.Mappings;

namespace CarRental.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseOracle(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));

            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // Services
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
