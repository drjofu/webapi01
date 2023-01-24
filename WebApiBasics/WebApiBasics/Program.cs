using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApiBasics.Models;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection einrichten
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// eigene DI-Definitionen hinzufügen
builder.Services.AddSingleton<Personenliste>();

builder.Services.AddSingleton<IBeispiel, A>();
builder.Services.AddSingleton<IBeispiel, B>();
builder.Services.AddSingleton<IBeispiel, C>();
//builder.Services.TryAddSingleton<Personenliste>();

builder.Services.AddOptions<FirmaConfig>()
  .Bind(builder.Configuration.GetSection("Firma"))
  .ValidateDataAnnotations()
  .ValidateOnStart();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string? name)=> $"Hallo {name} {name?.Length ?? 0}");

app.Run();
