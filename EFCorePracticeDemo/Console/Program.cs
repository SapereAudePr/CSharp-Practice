using Domain.Entities;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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

        //var test = await db.Employees
        //    .AsNoTracking()
        //    .Where(x => x.Person.Name == "Alicia")
        //    .Select(x => x.Person)
        //    .ToListAsync();


        //foreach (var item in test)
        //{
        //    System.Console.WriteLine(item.Name);
        //    System.Console.WriteLine(item.LastName);
        //}


        //var teams = await db.Employees
        //    .AsNoTracking()
        //    .OrderBy(x => x.Id)
        //    .ThenBy(x => x.Person.Name)
        //    .ToListAsync();

        //var teams2 = await db.Employees
        //    .AsNoTracking()
        //    .OrderByDescending(x => x.Id)
        //    .ThenByDescending(x => x.Person.LastName)
        //    .ToListAsync();

        //var linqSyntax = await (from team in db.Employees
        //                        orderby team.Id, team.Person.Id descending
        //                        select team)
        //                  .AsNoTracking()
        //                  .ToListAsync();

        // returns the entire Employee object that has the highest PersonId
        // Type <Employee>
        //var maxBy = db.Employees.Include(x => x.Person).MaxBy(x => x.PersonId);

        //System.Console.WriteLine(maxBy?.Person.Name);

        // returns only the highest number found in that column.
        // Type <int>
        //int max = db.Employees.Max(x => x.PersonId);

        //System.Console.WriteLine(max);

        //// asynchronous version of Max
        //// Type <int>
        //int maxAsync = await db.Employees.MaxAsync(x => x.PersonId);

        //System.Console.WriteLine(maxAsync);


        //var maxBy = await db.Employees
        //    .Include(x => x.Person)
        //    .OrderByDescending(x => x.PersonId)
        //    .FirstOrDefaultAsync();

        //if (maxBy is null)
        //    return;

        //System.Console.WriteLine(maxBy.Id);


        //var minBy = await db.Employees
        //    .Include(x => x.Person)
        //    .OrderBy(x => x.PersonId)
        //    .FirstOrDefaultAsync();

        //if (minBy is null)
        //    return;

        //System.Console.WriteLine(minBy.Id);


        //var getAll = await db.Employees.Include(x => x.Person).Include(x => x.Corporate).Skip(0 * 2).Take(3).ToListAsync();


        //foreach (var item in getAll)
        //{
        //    System.Console.WriteLine($"{item.Person.Name} - {item.Person.LastName}");
        //    System.Console.WriteLine($"{item.Corporate.Name}");
        //}

        //System.Console.WriteLine(getAll.FirstOrDefault(x => x.PersonId == 1));


        //var employee = await db.Employees
        //    .AsNoTracking()
        //    .Include(x => x.Person)
        //    .Select(x => new {x.Person.Name, x.PersonId })
        //    .ToListAsync();


        var asList = await db.Employees.AsNoTracking().Include(x => x.Person).ToListAsync();

        asList = asList.Where(x => x.PersonId == 1).ToList();

        foreach (var item in asList)
        {
            System.Console.WriteLine($"{item.Person.Name} - {item.PersonId}");
        }


        var asQueryable = db.Employees.AsNoTracking().Select(x => new { x.Person.Name, x.PersonId }).AsQueryable();

        asQueryable = asQueryable.Where(x => x.PersonId == 1);

        foreach (var item in asQueryable)
        {
            System.Console.WriteLine($"{item.Name} - {item.PersonId}");
        }

        var stringResult = await db.Employees
            .AsNoTracking()
            .Where(x => x.PersonId == 1)
            .Select(x => new { x.Person.Name, x.PersonId })
            .ToListAsync();

        foreach (var item in stringResult)
        {
            System.Console.WriteLine($"{item.Name} - {item.PersonId}");
        }


        var test = await db.Employees
            .AsNoTracking()
            .Where(x => x.PersonId == 1)
            //.Select(x => new {x.Person.Name, x.PersonId, x.Role})
            .Select(x => x)
            .ToListAsync();

        foreach (var item in test)
        {
            System.Console.WriteLine($"{item.Person.Name} - {item.PersonId} - {item.Role}");
        }

        System.Console.ReadKey();
    }
}
