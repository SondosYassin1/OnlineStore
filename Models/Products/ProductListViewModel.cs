namespace OnlineStore.Models.Products
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public ProductFilterViewModel Filter { get; set; } = new ProductFilterViewModel();
        public PaginationInfo Pagination { get; set; } = new PaginationInfo();
        public string Title { get; set; } = "Product Management";
    }
}
