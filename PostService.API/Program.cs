using Mapster;
using Microsoft.EntityFrameworkCore;
using PostService.API.Models;
using PostService.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Connection String
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Register AppDbContext
builder.Services.AddDbContextPool<AppDbContext>(db => db.UseSqlServer(connectionString));

// Register PostService
builder.Services.AddScoped<IPostServices, PostServices>();

// Register Mapster
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
