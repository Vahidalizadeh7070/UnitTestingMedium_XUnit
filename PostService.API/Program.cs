using Microsoft.EntityFrameworkCore;
using PostService.API.Models;
using PostService.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Connection String
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Register AppDbContext
builder.Services.AddDbContextPool<AppDbContext>(db => db.UseSqlServer(connectionString));

// Register PostService
builder.Services.AddScoped<IPostServices, PostServices>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
