var builder = WebApplication.CreateBuilder(args);

// Listen on all interfaces (for Docker)
builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

app.MapGet("/", () => "Hello from .NET 8 Minimal API in Docker!");

app.Run();
