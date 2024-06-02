namespace TasksApi.Domain.Model;

public class TasksServices(TasksDbContext context)
{
    public TasksDbContext Context { get; set; } = context;
}
