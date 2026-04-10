using Infrastructure.Interceptor;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditInterceptor>();

        services.AddDbContext<HospitalDbContext>((sp, options) =>
        {
            var auditInterceptor = sp.GetRequiredService<AuditInterceptor>();

            options.UseSqlServer(configuration.
                GetConnectionString("HospitalDbConnection"))
            .AddInterceptors(auditInterceptor);
        });

        return services;
    }
}
