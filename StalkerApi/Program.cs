using StalkerApi;
using StalkerApi.DatabaseConnection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<StalkerDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

GetStalkerById(app);
GetAllStalkers(app);

app.Run();
return;

void GetStalkerById(IEndpointRouteBuilder webApp)
{
	webApp.MapGet("/stalker/{i}", (string i) =>
	{
		var stalker = new Stalker();
		return stalker;
	});
}

void GetAllStalkers(IEndpointRouteBuilder webApp)
{
	webApp.MapGet("/stalker", () =>
	{
		List<Stalker> stalkers = new();
		return stalkers;
	});
}