using CompanyX.API.BusinessLogic.Interfaces;
using CompanyX.API.BusinessLogic.Services;
using CompanyX.API.DataAccess.DatabaseContext;
using CompanyX.API.DataAccess.Interfaces;
using CompanyX.API.DataAccess.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CompanyXDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")), ServiceLifetime.Transient);
builder.Services.AddScoped<IDataSeedingService, DataSeedingService>();
builder.Services.AddScoped<IDataSeedingRepository, DataSeedingRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "CompanyX MGMT System",
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var dataInitializer = scope.ServiceProvider.GetRequiredService<IDataSeedingService>();
        await dataInitializer.SeedInitialDataAsync();
    }
    catch (SqlException ex)
    {
        Console.WriteLine("SQL server error occurred: " + ex.Message);
    }
    catch (ValidationException ex)
    {
        Console.WriteLine("Validation error occurred: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Server error occurred: " + ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompanyX.API");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
