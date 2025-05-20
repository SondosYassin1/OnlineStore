using OnlineStore.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        // Static list of products for demo purposes
        private static List<ProductViewModel> _products = new List<ProductViewModel>
        {
            new ProductViewModel
            {
                Id = 1,
                Name = "Wireless Headphones",
                Category = "Electronics",
                Price = 89.99m,
                OldPrice = 129.99m,
                ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Wireless+Headphones",
                IsActive = true,
                IsFeatured = true,
                IsOnSale = true
            },
            new ProductViewModel
            {
                Id = 2,
                Name = "Smart Watch",
                Category = "Electronics",
                Price = 199.99m,
                OldPrice = 249.99m,
                ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Smart+Watch",
                IsActive = true,
                IsFeatured = true,
                IsOnSale = false
            },
            new ProductViewModel
            {
                Id = 3,
                Name = "Casual T-Shirt",
                Category = "Clothing",
                Price = 24.99m,
                OldPrice = 34.99m,
                ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Casual+T-Shirt",
                IsActive = true,
                IsFeatured = false,
                IsOnSale = true
            },
            new ProductViewModel
            {
                Id = 4,
                Name = "Coffee Maker",
                Category = "Home & Kitchen",
                Price = 59.99m,
                OldPrice = 79.99m,
                ImageUrl = "https://placehold.co/300x300/f8f9fa/0d6efd?text=Coffee+Maker",
                IsActive = false,
                IsFeatured = false,
                IsOnSale = false
            },
            new ProductViewModel
            {
                Id = 5,
                Name = "Premium Headphones",
                Category = "Electronics",
                Price = 79.99m,
                OldPrice = 129.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Headphones",
                IsActive = true,
                IsFeatured = true,
                IsOnSale = true
            },
            new ProductViewModel
            {
                Id = 6,
                Name = "Fitness Smartwatch",
                Category = "Electronics",
                Price = 189.99m,
                OldPrice = 249.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Smartwatch",
                IsActive = true,
                IsFeatured = false,
                IsOnSale = true
            },
            new ProductViewModel
            {
                Id = 7,
                Name = "Designer T-Shirt",
                Category = "Clothing",
                Price = 29.99m,
                OldPrice = 39.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=T-Shirt",
                IsActive = true,
                IsFeatured = false,
                IsOnSale = false
            },
            new ProductViewModel
            {
                Id = 8,
                Name = "Smart Coffee Maker",
                Category = "Home & Kitchen",
                Price = 69.99m,
                OldPrice = 89.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Coffee+Maker",
                IsActive = true,
                IsFeatured = false,
                IsOnSale = false
            },
            new ProductViewModel
            {
                Id = 9,
                Name = "Bluetooth Speaker",
                Category = "Electronics",
                Price = 49.99m,
                OldPrice = 69.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Speaker",
                IsActive = true,
                IsFeatured = true,
                IsOnSale = true
            },
            new ProductViewModel
            {
                Id = 10,
                Name = "Kitchen Blender",
                Category = "Home & Kitchen",
                Price = 39.99m,
                OldPrice = 59.99m,
                ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Blender",
                IsActive = false,
                IsFeatured = false,
                IsOnSale = true
            }
        };

        // Static list of categories for demo purposes
        private static readonly List<SelectListItem> _categories = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Electronics" },
            new SelectListItem { Value = "2", Text = "Clothing" },
            new SelectListItem { Value = "3", Text = "Home & Kitchen" }
        };

        // Static list of statuses for dropdown
        private static readonly List<SelectListItem> _statuses = new List<SelectListItem>
        {
            new SelectListItem { Value = "active", Text = "Active" },
            new SelectListItem { Value = "inactive", Text = "Inactive" },
            new SelectListItem { Value = "featured", Text = "Featured" },
            new SelectListItem { Value = "sale", Text = "On Sale" }
        };
        public IActionResult Index(ProductFilterViewModel filter)
        {
           // initialize default value to filter
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 3 : filter.PageSize;

            // drop downe of the filter
            filter.Categories = _categories;
            filter.Statuses = _statuses;

            // apply filter
            var filteredProducts = _products.AsQueryable();
            if (!string.IsNullOrEmpty(filter.CategoryId))
            {
                var categoryName = _categories.FirstOrDefault(c => c.Value == filter.CategoryId )?.Text;
                if (categoryName != null)
                {
                    filteredProducts = filteredProducts.Where(p => p.Category == categoryName);
                }
            }

            if (!string.IsNullOrEmpty(filter.Status)) {
                filteredProducts = filter.Status switch
                {
                    "active" => filteredProducts.Where(p => p.IsActive),
                    "inactive" => filteredProducts.Where(p => !p.IsActive),
                    "featured" => filteredProducts.Where(p => p.IsFeatured),
                    "sale" => filteredProducts.Where(p => p.IsOnSale),
                    _ => filteredProducts
                };
            }

            if (!string.IsNullOrEmpty(filter.SearchTerm))
            {
                string searchTerm = filter.SearchTerm.ToLower();
                filteredProducts =filteredProducts.Where(p =>
                p.Name.ToLower().Contains(searchTerm) ||
                p.Category.ToLower().Contains(searchTerm));
            }

            // calculat pagination
            var totalItem = filteredProducts.Count();
            var totalPages = (int)Math.Ceiling(totalItem / (double)filter.PageSize);

           // apply pagination
           var paginatedProducts = filteredProducts
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            // creat the model
            var model = new ProductListViewModel
            {
                Products = paginatedProducts,
                Filter = filter,
                Pagination = new PaginationInfo
                {
                    CurrentPage = filter.Page,
                    PageSize = filter.PageSize,
                    TotalItems = totalItem,
                    TotalPages = totalPages
                },
                Title = "Product Management"
            };

           // return model
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            TempData["SuccessMessage"] = $"Product '{product.Name}' was successfully deleted";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleStatus(int id, string status)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)  // really return
            {
                return NotFound();
            }

            switch (status.ToLower())
            {
                case "active":
                    product.IsActive = !product.IsActive;
                    break;
                case "featured":
                    product.IsFeatured = !product.IsFeatured;
                    break;
                case "sale":
                    product.IsOnSale = !product.IsOnSale;
                    break;
                default:
                    return BadRequest("Invalid status");

            }
            return PartialView("_ProductItemPartial", product);
        }

    }
}
