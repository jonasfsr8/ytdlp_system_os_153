using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ytdlp_system_os_153.Domain.Interfaces;
using ytdlp_system_os_153.Infrastructure.Context;
using ytdlp_system_os_153.Infrastructure.Repositories;

namespace ytdlp_system_os_153.Infrastructure
{
    public static class ServiceInfrastructureExtensions
    {
        public static IServiceCollection ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(
                    connectionString, 
                    b => b.MigrationsAssembly(
                        typeof(ServiceInfrastructureExtensions).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
