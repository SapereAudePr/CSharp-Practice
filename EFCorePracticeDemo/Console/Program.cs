using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console;

internal class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddInfrastructure();

        var provider = services.BuildServiceProvider();

        using var scope = provider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DemoDbContext>;


    }
}
