using Calculator.Model.Context;
using Calculator.Services;
using Calculator.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Connect to SQL 
var connection = builder.Configuration.GetConnectionString("MySqlConnection");


builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySql(connection, ServerVersion.AutoDetect(connection))
);
//Dependecy Injection

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
//builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
