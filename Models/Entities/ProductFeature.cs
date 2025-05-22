namespace OnlineStore.Models.Entities
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; } = string.Empty;

        // Navigation property
        public Product? Product { get; set; }
    }
}
