using EfficiencyDental.Application.Business.Tenant;
using EfficiencyDental.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureInfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>((s, o) =>
        {
            var connectionString = s.GetService<ITenantService>().GetTenantConnectionString();
            if (connectionString is null)
            {
                o.UseNpgsql(configuration["ConnectionStrings:Context"],
                        x => x.MigrationsAssembly("EfficiencyDental.Infrastructure"))
                            .UseSnakeCaseNamingConvention();
            }
            else
            {
                o.UseNpgsql(connectionString,
                        x => x.MigrationsAssembly("EfficiencyDental.Infrastructure"))
                    .UseSnakeCaseNamingConvention();
            }
        });
        
        services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationContext>());
        services.AddScoped<ApplicationContextInitializer>();

        return services;
    }
}