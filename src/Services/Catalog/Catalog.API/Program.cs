using BuildingBlocks.Behaviors;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviors<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure https request pipeline
app.MapCarter();

app.UseExceptionHandler(exceptionHandlerApp => {
    exceptionHandlerApp.Run(async context =>
    {
        var exeception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if(exeception == null)
        {
            return;
        }

        var problemDetail = new ProblemDetails
        {
            Title = exeception.Message,
            Status =  StatusCodes.Status500InternalServerError,
            Detail = exeception.StackTrace
        };

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exeception, exeception.Message);

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(problemDetail);
    });
});

app.Run();
