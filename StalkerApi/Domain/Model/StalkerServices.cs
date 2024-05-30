namespace StalkerApi.Domain.Model;

internal class StalkerServices(StalkerDbContext context)
{
    internal StalkerDbContext Context { get; } = context;
}
