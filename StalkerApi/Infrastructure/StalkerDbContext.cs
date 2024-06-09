using Microsoft.EntityFrameworkCore;

namespace StalkerApi.Infrastructure;

public class StalkerDbContext : DbContext
{
    internal DbSet<Stalker> Stalkers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

        optionsBuilder.UseNpgsql(config.GetConnectionString("StalkerPGSQL"), builder =>
        {
            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
        });
    }
}