using ClienteApi.Data;
using ClienteApi.Middleware;
using Microsoft.EntityFrameworkCore;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura EF Core con SQLite
builder.Services.AddDbContext<ClienteDbContext>(options =>
    options.UseMySql("server=localhost;database=clientesdb;user=root;password=;",
    ServerVersion.AutoDetect("server=localhost;database=clientesdb;user=root;password=;")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cliente API", Version = "v1" });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseApiKeyMiddleware();

app.UseAuthorization();
app.MapControllers();
app.Run();
