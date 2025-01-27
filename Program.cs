using Microsoft.EntityFrameworkCore;
using MerchantCategoriesApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure the Web Host to listen on all interfaces
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure() // Enables retry for transient failures
    ));

// Build the application
var app = builder.Build();

// Apply migrations and seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    // Check if the database exists before attempting migration
    if (!context.Database.CanConnect())
    {
        context.Database.Migrate(); // Applies migrations and creates the database if it doesn't exist
    }

    // Seed the database
    DbSeeder.Seed(context);
}

// Configure the HTTP request pipeline
app.MapControllers();

// Run the application
app.Run();
