using StalkerApi.Domain.Model;

namespace StalkerApi;

public static class StalkerApi
{
    public static void MapStalkerApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("stalker/{id:int}", GetStalkerAsync);
    }

    private static async Task GetStalkerAsync(HttpContext context, [AsParameters] StalkerServices stalkerServices)
    {
        stalkerServices.Context.Stalkers.FindAsync();
    }
}
