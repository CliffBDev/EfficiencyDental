using EfficiencyDental.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureInfraServices
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(
            options => options.UseNpgsql(configuration["ConnectionStrings:Context"],
                x => x.MigrationsAssembly("EfficiencyDental.Infrastructure"))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<IApplicationDbContext>(p => p.GetRequiredService<ApplicationContext>());
        services.AddScoped<ApplicationContextInitializer>();

        return services;
    }
}