using EFDemo.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Repositories_.IRepositories;
using Repositories_.Repositories;
using Serilog;

namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<RestaurantDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Data"))
        );

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "Logs");
        string filePath = Path.Combine(folderPath, "Logs.txt");

        builder.Host.UseSerilog((context, config) =>
        {
            config
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(filePath, rollingInterval: RollingInterval.Day);
        });

        builder.Services.AddScoped<ICountryRepository, SQLCountryRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
