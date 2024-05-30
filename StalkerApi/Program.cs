using StalkerApi.Core.Model;
using StalkerApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<StalkerDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();

return;