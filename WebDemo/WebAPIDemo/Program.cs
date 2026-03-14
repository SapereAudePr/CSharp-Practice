
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAPIDemo.Data;
using WebAPIDemo.Repositories;

namespace WebAPIDemo
{
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

            builder.Services.AddDbContext<WebDemoDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebDemoConnectionString")));

            builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();

            builder.Services.AddAutoMapper(cfg => { },
                Assembly.GetExecutingAssembly());

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
}
