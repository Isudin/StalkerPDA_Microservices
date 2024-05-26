using Microsoft.EntityFrameworkCore;
using StalkerApi.Core.Model;

namespace StalkerApi.Infrastructure.Database;

internal class StalkerDbContext : DbContext
{
    internal DbSet<Stalker> Stalkers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

        optionsBuilder.UseNpgsql(config.GetConnectionString("StalkerPGSQL"));
    }
}