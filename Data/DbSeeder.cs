using MerchantCategoriesApi.Models;

namespace MerchantCategoriesApi.Data;

public static class DbSeeder
{
    public static void Seed(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "חלב וגבינות",
                    Products = new List<Product>
                    {
                        new Product { Name = "חלב" },
                        new Product { Name = "גבינה צהובה" },
                        new Product { Name = "יוגורט" }
                    }
                },
                new Category
                {
                    Name = "בשר",
                    Products = new List<Product>
                    {
                        new Product { Name = "סטייק" },
                        new Product { Name = "המבורגר" },
                        new Product { Name = "שניצל" }
                    }
                },
                new Category
                {
                    Name = "טואלטיקה",
                    Products = new List<Product>
                    {
                        new Product { Name = "שמפו" },
                        new Product { Name = "סבון" },
                        new Product { Name = "מרכך שיער" }
                    }
                },
                new Category
                {
                    Name = "ירקות ופירות",
                    Products = new List<Product>
                    {
                        new Product { Name = "עגבניה" },
                        new Product { Name = "מלפפון" },
                        new Product { Name = "בננה" }
                    }
                }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
