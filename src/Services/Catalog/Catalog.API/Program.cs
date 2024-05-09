var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add services to container

app.MapGet("/", () => "Hello World!");

// Configure https request pipeline

app.Run();
