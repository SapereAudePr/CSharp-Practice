using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Console;

internal class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddInfrastructure(context.Configuration);
            })
            .Build();


        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DemoDbContext>();

        var test = await db.Employees
            .AsNoTracking()
            .Where(x => x.Person.Name == "Alicia")
            .Select(x => x.Person)
            .ToListAsync();


        foreach (var item in test)
        {
            System.Console.WriteLine(item.Name);
            System.Console.WriteLine(item.LastName);
        }


        System.Console.ReadKey();
    }
}
