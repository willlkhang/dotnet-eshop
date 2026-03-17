using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

//add Services to the container

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();


builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// builder.Services.AddHealthChecks()
//     .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();

//configure the HTTP request pipeline
app.MapCarter();

app.UseExceptionHandler(options => { });
// app.UseHealthChecks("/health", 
//     new HealthCheckOptions
//     {
//         ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//     });

app.Run();