namespace StalkerApi.Domain.Model;

public class StalkerServices(StalkerDbContext context)
{
    public StalkerDbContext Context { get; } = context;
}
