using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Web
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

            builder.Services.AddDbContext<BankDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BankDemoCS")));

            var app = builder.Build();

            //app.MapGet("/api/demo", async (BankDbContext dbContext) =>
            //{
            //    var results = await dbContext.BankChurns
            //    .Select(x => new
            //    {
            //        x.Surname,
            //        x.Balance,
            //        x.Tenure

            //    }).ToListAsync();

            //    Console.WriteLine(results.Count);

            //    return Results.Ok(results);
            //});

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
