var builder = WebApplication.CreateBuilder(args);
// Add service to container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
