using Microsoft.EntityFrameworkCore;
using OnlineStore.Models.Entities;

namespace OnlineStore.Data
{
    public static class DbInitializer
    {
        public static async Task InizializeAsync(IServiceProvider serviceProvider, IHostEnvironment env)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (env.IsDevelopment())
            {
                await context.Database.MigrateAsync();
            }

            await SeedDataAsync(context);
        }

        private static async Task SeedDataAsync(ApplicationDbContext context)
        {
            if (await context.Categories.AnyAsync() || await context.Products.AnyAsync())
            {
                return; // DB has been seeded
            }

            var categories = new List<Category>
            {
                new Category { Name = "Electronics", Slug = "electronics", IconClass = "fas fa-laptop", Description = "The latest gadgets and tech innovations." },
                new Category { Name = "Clothing", Slug = "clothing", IconClass = "fas fa-tshirt", Description = "Fashionable apparel for all ages." },
                new Category { Name = "Home & Kitchen", Slug = "home", IconClass = "fas fa-home", Description = "Everything you need for your home." }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();

            var electronics = await context.Categories.FirstAsync(c => c.Name == "Electronics");
            var clothing = await context.Categories.FirstAsync(c => c.Name == "Clothing");
            var home = await context.Categories.FirstAsync(c => c.Name == "Home & Kitchen");

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Wireless Headphones",
                    Sku = "WH-001",
                    CategoryId = electronics.Id,
                    Brand = "AudioTech",
                    Price = 89.99m,
                    OldPrice = 129.99m,
                    IsOnSale = true,
                    StockQuantity = 45,
                    LowStockThreshold = 10,
                    IsActive = true,
                    IsFeatured = true,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Wireless+Headphones",
                    Tags = "wireless,audio,bluetooth",
                    Weight = 0.3m,
                    ShortDescription = "Premium wireless headphones with noise cancellation.",
                    Description = "Experience crystal-clear sound with our premium wireless headphones. Featuring advanced noise cancellation technology and comfortable ear cushions for extended wear."
                },
                new Product
                {
                    Name = "Smart Watch",
                    Sku = "SW-002",
                    CategoryId = electronics.Id,
                    Brand = "TechWear",
                    Price = 199.99m,
                    OldPrice = 249.99m,
                    IsOnSale = true,
                    StockQuantity = 30,
                    LowStockThreshold = 5,
                    IsActive = true,
                    IsFeatured = true,
                    IsNew = true,
                    ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Smart+Watch",
                    Tags = "smartwatch,wearable,fitness",
                    Weight = 0.05m,
                    ShortDescription = "Track your fitness and stay connected with our Smart Watch.",
                    Description = "This advanced Smart Watch combines fitness tracking capabilities with smart notifications. Monitor your heart rate, count steps, and track sleep patterns."
                },
                new Product
                {
                    Name = "Casual T-Shirt",
                    Sku = "CT-003",
                    CategoryId = clothing.Id,
                    Brand = "Urban Style",
                    Price = 24.99m,
                    OldPrice = 34.99m,
                    IsOnSale = true,
                    StockQuantity = 100,
                    LowStockThreshold = 20,
                    IsActive = true,
                    IsFeatured = false,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Casual+T-Shirt",
                    Tags = "tshirt,casual,cotton",
                    Weight = 0.2m,
                    ShortDescription = "Comfortable casual t-shirt for everyday wear.",
                    Description = "This casual t-shirt is made from 100% cotton for maximum comfort. Available in multiple colors and sizes."
                },
                new Product
                {
                    Name = "Coffee Maker",
                    Sku = "CM-004",
                    CategoryId = home.Id,
                    Brand = "HomeEssentials",
                    Price = 59.99m,
                    OldPrice = 79.99m,
                    IsOnSale = false,
                    StockQuantity = 15,
                    LowStockThreshold = 3,
                    IsActive = false,
                    IsFeatured = false,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Coffee+Maker",
                    Tags = "coffee,kitchen,appliance",
                    Weight = 2.5m,
                    ShortDescription = "Brew delicious coffee at home with our easy-to-use coffee maker.",
                    Description = "Make barista-quality coffee in the comfort of your own home. Features programmable brewing, auto-shutoff, and a removable water reservoir."
                },
                new Product
                {
                    Name = "Premium Headphones",
                    Sku = "PH-005",
                    CategoryId = electronics.Id,
                    Brand = "SoundMaster",
                    Price = 79.99m,
                    OldPrice = 129.99m,
                    IsOnSale = true,
                    StockQuantity = 25,
                    LowStockThreshold = 5,
                    IsActive = true,
                    IsFeatured = true,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Headphones",
                    Tags = "premium,audio,noise-cancelling",
                    Weight = 0.35m,
                    ShortDescription = "High-quality headphones with superior sound clarity.",
                    Description = "Our premium headphones deliver exceptional sound quality with deep bass and crisp highs. The ergonomic design ensures comfort for extended listening sessions."
                },
                new Product
                {
                    Name = "Fitness Smartwatch",
                    Sku = "FS-006",
                    CategoryId = electronics.Id,
                    Brand = "FitTech",
                    Price = 189.99m,
                    OldPrice = 249.99m,
                    IsOnSale = true,
                    StockQuantity = 40,
                    LowStockThreshold = 8,
                    IsActive = true,
                    IsFeatured = false,
                    IsNew = true,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Smartwatch",
                    Tags = "fitness,smartwatch,health",
                    Weight = 0.05m,
                    ShortDescription = "Advanced fitness tracking with smart features.",
                    Description = "Track your workouts, monitor your heart rate, and receive notifications from your phone with our fitness smartwatch. Water-resistant up to 50 meters."
                },
                new Product
                {
                    Name = "Designer T-Shirt",
                    Sku = "DT-007",
                    CategoryId = clothing.Id,
                    Brand = "Fashion Forward",
                    Price = 29.99m,
                    OldPrice = 39.99m,
                    IsOnSale = false,
                    StockQuantity = 80,
                    LowStockThreshold = 15,
                    IsActive = true,
                    IsFeatured = false,
                    IsNew = true,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=T-Shirt",
                    Tags = "designer,fashion,premium",
                    Weight = 0.2m,
                    ShortDescription = "Trendy designer t-shirt with unique patterns.",
                    Description = "Stand out with our designer t-shirt featuring exclusive patterns and premium fabric. Made with sustainable materials for comfort and style."
                },
                new Product
                {
                    Name = "Smart Coffee Maker",
                    Sku = "SCM-008",
                    CategoryId = home.Id,
                    Brand = "SmartHome",
                    Price = 69.99m,
                    OldPrice = 89.99m,
                    IsOnSale = false,
                    StockQuantity = 20,
                    LowStockThreshold = 4,
                    IsActive = true,
                    IsFeatured = false,
                    IsNew = true,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Coffee+Maker",
                    Tags = "smart,coffee,wifi,kitchen",
                    Weight = 2.3m,
                    ShortDescription = "WiFi-enabled coffee maker you can control from your phone.",
                    Description = "Brew coffee from anywhere with our smart coffee maker. Schedule brewing times, adjust strength, and receive notifications when your coffee is ready, all from your smartphone."
                },
                new Product
                {
                    Name = "Bluetooth Speaker",
                    Sku = "BS-009",
                    CategoryId = electronics.Id,
                    Brand = "SoundWave",
                    Price = 49.99m,
                    OldPrice = 69.99m,
                    IsOnSale = true,
                    StockQuantity = 35,
                    LowStockThreshold = 7,
                    IsActive = true,
                    IsFeatured = true,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Speaker",
                    Tags = "bluetooth,speaker,portable",
                    Weight = 0.5m,
                    ShortDescription = "Portable Bluetooth speaker with powerful sound.",
                    Description = "Take your music anywhere with our portable Bluetooth speaker. Features 10-hour battery life, water resistance, and powerful 360-degree sound."
                },
                new Product
                {
                    Name = "Kitchen Blender",
                    Sku = "KB-010",
                    CategoryId = home.Id,
                    Brand = "BlendMaster",
                    Price = 39.99m,
                    OldPrice = 59.99m,
                    IsOnSale = true,
                    StockQuantity = 0,
                    LowStockThreshold = 5,
                    IsActive = false,
                    IsFeatured = false,
                    IsNew = false,
                    ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Blender",
                    Tags = "blender,kitchen,appliance",
                    Weight = 3.0m,
                    ShortDescription = "Powerful blender for smoothies and food preparation.",
                    Description = "Make smoothies, soups, and sauces with our high-powered blender. Features multiple speed settings and durable stainless steel blades."
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
            var features = new List<ProductFeature>
            {
                new ProductFeature { ProductId = products[0].Id, Description = "Noise cancellation technology" },
                new ProductFeature { ProductId = products[0].Id, Description = "30-hour battery life" },
                new ProductFeature { ProductId = products[0].Id, Description = "Bluetooth 5.0 connectivity" },

                new ProductFeature { ProductId = products[1].Id, Description = "Heart rate monitoring" },
                new ProductFeature { ProductId = products[1].Id, Description = "Sleep tracking" },
                new ProductFeature { ProductId = products[1].Id, Description = "Water resistant (50m)" },
                new ProductFeature { ProductId = products[1].Id, Description = "Smart notifications" },

                new ProductFeature { ProductId = products[2].Id, Description = "100% cotton material" },
                new ProductFeature { ProductId = products[2].Id, Description = "Multiple colors available" },
                new ProductFeature { ProductId = products[2].Id, Description = "Machine washable" },

                new ProductFeature { ProductId = products[3].Id, Description = "Programmable brewing" },
                new ProductFeature { ProductId = products[3].Id, Description = "Auto-shutoff feature" },
                new ProductFeature { ProductId = products[3].Id, Description = "Removable water reservoir" }
            };

            await context.ProductFeatures.AddRangeAsync(features);
            await context.SaveChangesAsync();

        }
    }
}
