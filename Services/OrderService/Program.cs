using EventSystem.OrderService.Application.Handler;
using EventSystem.OrderService.Application.Interfaces;
using EventSystem.OrderService.Infrastructure.Messaging;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApplicationPartManager(manager =>
    {
        manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
    });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    // Ensure the generator documents internal controllers
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        // Custom logic to include internal types if needed
        return Task.CompletedTask;
    });
});

//Configure MassTransit (Publisher)
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });
});

builder.Services.AddScoped<CreateOrderHandler>();
builder.Services.AddScoped<IEventPublisher,EventPublisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


internal sealed class InternalControllerFeatureProvider : ControllerFeatureProvider
{
    protected override bool IsController(TypeInfo typeInfo)
    {
        // This allows internal classes to be treated as controllers
        if (!typeInfo.IsClass || typeInfo.IsAbstract || typeInfo.ContainsGenericParameters)
            return false;

        return typeInfo.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase) ||
               typeInfo.IsDefined(typeof(ApiControllerAttribute));
    }
}