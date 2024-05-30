using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StalkerApi.Core.Model;
using StalkerApi.Domain.Model;

namespace StalkerApi;

public static class StalkerApi
{
    public static void MapStalkerApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("stalker/{id:int}", GetStalkerAsync);
        app.MapGet("stalker/byLocation/{location:int}", GetNearbyStalkersAsync);
    }

    private static async Task<Results<Ok<Stalker>, NotFound>> GetStalkerAsync(HttpContext context, 
        [AsParameters] StalkerServices stalkerServices, int id)
    {
        var stalker = await stalkerServices.Context.Stalkers.FindAsync(typeof(Stalker), new[] { id });
        if (stalker == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(stalker);
    }

    private static async Task<List<Stalker>> GetNearbyStalkersAsync(HttpContext context, [AsParameters] StalkerServices stalkerServices, int location)
    {
        return await stalkerServices.Context.Stalkers.Where(x => x.CurrentLocationID == location).ToListAsync();
    }
}
