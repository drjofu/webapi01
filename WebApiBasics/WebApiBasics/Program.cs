var builder = WebApplication.CreateBuilder(args);

// Dependency Injection einrichten
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string? name)=> $"Hallo {name} {name?.Length ?? 0}");

app.Run();
