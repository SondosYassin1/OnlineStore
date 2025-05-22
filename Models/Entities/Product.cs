namespace OnlineStore.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string? Brand { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public bool IsOnSale { get; set; }
        public int? StockQuantity { get; set; }
        public int? LowStockThreshold { get; set; }
        public bool TrackInventory { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public string? Tags { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public Category? Category { get; set; }
        public ICollection<ProductFeature> Features { get; set; } = new List<ProductFeature>();
    }
}
