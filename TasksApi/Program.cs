using TasksApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkMongoDB()
                .AddDbContext<TasksDbContext>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapTasksApi();

app.Run();
