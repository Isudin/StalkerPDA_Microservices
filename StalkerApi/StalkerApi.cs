using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace StalkerApi;

public static class StalkerApi
{
    public static void MapStalkerApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("stalker/{id:int}", GetStalkerAsync);
        app.MapGet("stalker/byLocation/{locationId:int}", GetNearbyStalkersAsync);
        app.MapPost("stalker", PostStalkerAsync);
        app.MapPut("stalker", UpdateStalkerAsync);
    }

    private static async Task<Results<Ok<Stalker>, NotFound<string>>> GetStalkerAsync([AsParameters] StalkerServices stalkerServices, int id)
    {
        var stalker = await stalkerServices.Context.Stalkers.FindAsync(id);
        if (stalker == null)
            return TypedResults.NotFound("Stalker not found.");

        return TypedResults.Ok(stalker);
    }

    private static async Task<List<Stalker>> GetNearbyStalkersAsync([AsParameters] StalkerServices stalkerServices, int locationId)
    {
        return await stalkerServices.Context.Stalkers.Where(x => x.CurrentLocationID == locationId).ToListAsync();
    }

    private static async Task<Results<Created, BadRequest<string>>> PostStalkerAsync([AsParameters] StalkerServices stalkerServices, 
        Stalker stalker)
    {
        if (stalker.Name == null)
            return TypedResults.BadRequest("Name is required.");

        if (stalker.CurrentLocationID < 1)
            return TypedResults.BadRequest("CurrentLocationID is required.");
        
        var localStalker = new Stalker()
        {
            CurrentLocationID = stalker.CurrentLocationID,
            Status = stalker.Status,
            Surname = stalker.Surname,
            Name = stalker.Name,
            Nickname = stalker.Nickname,
            ReputationPoints = stalker.ReputationPoints,
        };

        stalkerServices.Context.Add(localStalker);
        await stalkerServices.Context.SaveChangesAsync();

        return TypedResults.Created($"stalker/{stalker.Id}");
    }

    private static async Task<Results<Created, NotFound<string>>> UpdateStalkerAsync([AsParameters] StalkerServices stalkerServices,
        Stalker stalker)
    {
        var stalkerFromDatabase = await stalkerServices.Context.Stalkers.SingleOrDefaultAsync();
        if (stalkerFromDatabase == null)
            return TypedResults.NotFound($"Stalker with ID {stalkerFromDatabase} not found.");

        var stalkerEntry = stalkerServices.Context.Entry(stalkerFromDatabase);
        stalkerEntry.CurrentValues.SetValues(stalker);
        await stalkerServices.Context.SaveChangesAsync();

        return TypedResults.Created($"stalker/{stalker.Id}");
    }
}
