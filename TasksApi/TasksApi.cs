using Microsoft.AspNetCore.Http.HttpResults;

namespace TasksApi;

public static class TasksApi
{
    public static void MapTasksApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("task/{id:int}", GetTaskByIdAsync);
    }

    private static async Task<Results<Ok<Errand>, NotFound<string>>> GetTaskByIdAsync([AsParameters] TasksServices tasksServices, int id)
    {
        var errand = await tasksServices.Context.Tasks.FindAsync(id);
        if (errand == null)
            return TypedResults.NotFound("Task not found");
        
        return TypedResults.Ok(errand);
    }
}
