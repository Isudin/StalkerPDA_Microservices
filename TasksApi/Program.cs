var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEntityFrameworkMongoDB();

// Add services to the container.

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Map redirections

app.Run();
