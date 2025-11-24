using Microsoft.EntityFrameworkCore;
using NetWebAPI.Models;
using NetWebAPI.Models.DataManager;
using NetWebAPI.Models.Entities;
using NetWebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(
    option=> option.UseSqlServer(builder.Configuration.GetConnectionString("default"))
    );

builder.Services.AddScoped < IDataRepository<Product>,ProductDataManager>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
