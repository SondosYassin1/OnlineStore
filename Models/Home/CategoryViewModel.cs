namespace OnlineStore.Models.Home
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string IconClass { get; set; }
        public string Description { get; set; }

        //public bool IsActive { get; set; } = true;

        //// Navigation property
        //public ICollection<Product> Products { get; set; }

    }
}
