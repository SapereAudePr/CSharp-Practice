using Application.DTO;
using Application.Validators;
using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Register validators manually
        builder.Services.AddScoped<IValidator<CreateOrderDto>, CreateOrderDtoValidator>();
        builder.Services.AddScoped<IValidator<UpdateOrderDto>, UpdateOrderDtoValidator>();

        // Register validators automatically in the same assembly of CreateOrderDtoValidator.cs (Application class library in this case)
        //builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderDtoValidator>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection"));
        });

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
