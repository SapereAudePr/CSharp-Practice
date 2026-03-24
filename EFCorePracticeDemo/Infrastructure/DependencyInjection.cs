using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<DemoDbContext>(options =>
        options.UseSqlServer("Server=DESKTOP-CFHU0V4\\SQLEXPRESS;Database=EFPractice;Trusted_Connection=True;TrustServerCertificate=True;"));

        return services;
    }
}
