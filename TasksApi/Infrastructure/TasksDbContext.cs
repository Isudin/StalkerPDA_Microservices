using Microsoft.EntityFrameworkCore;

namespace TasksApi.Infrastructure
{
    public class TasksDbContext : DbContext
    {
        internal DbSet<Task> Tasks { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();

            optionsBuilder.UseMongoDB(config.GetConnectionString("StalkerMongoDb")!,
                config.GetSection("DatabaseNames")["StalkerMongoDb"]!);
        }
    }
}
