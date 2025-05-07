using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.Products
{
    public class ProductEditViewModel
    {
        // Basic Informatiom
        public int Id { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; } = string.Empty;


        [Display(Name = "SKU (Stock Keeping Unit)")]
        [Required(ErrorMessage = "SKU is required")]
        public string Sku { get; set; } = string.Empty;


        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public string CategoryId { get; set; } = string.Empty;


        [Display(Name = "Brand")]
        public string Brand { get; set; } = string.Empty;


        // Image
        [Display(Name = "Product Image")]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }

        // Pricing & Inventory 
        [Display(Name = "Regular Price ($)")]
        [Required(ErrorMessage = "Regular price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be grater than 0")]
        public decimal price { get; set; }

        [Display(Name = "Sale Price ($)")]
        public decimal? SalePrice { get; set; }

        [Display(Name = "Product is on sale")]
        public bool OnSale { get; set; }

        [Display(Name = "Stock Quantity")]
        public int? StockQuantity { get; set; }

        [Display(Name = "Low Stock Threshold")]
        public int LowStockThreshold { get; set; }

        [Display(Name = "Trak Inventory for this product")]
        public bool TrakInventory { get; set; } = true;

        // Display Setting
        [Display(Name = "Product is active")]
        public bool IsActive { get; set; }

        [Display(Name = "Feature is product")]
        public bool IsFeatured { get; set; }

        [Display(Name = "Mark as new arrival")]
        public bool IsNew {  get; set; }

        // Tags 

        [Display(Name = "Product Tags")]
        public string Tags { get; set; } = string.Empty;

           // Shipping Dimensions
        [Display(Name = "Product Weight (Kg)")]
        public decimal? Weight { get; set; }

        [Display(Name = "Length (cm)")]
        public decimal? Length { get; set; }

        [Display(Name = "Width (cm)")]
        public decimal? Width { get; set; }

        [Display(Name = "Height (cm)")]
        public decimal? Height { get; set; }

        // Description & Details 
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; } = string.Empty;

        [Display(Name = "Full Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Key Features")]
        public List<string> Features { get; set; } = new List<string>();

        // For dropdowns 
        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

    }
}
