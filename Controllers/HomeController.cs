using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OnlineStore.Models.Home;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public HomeController(ILogger<HomeController> logger
            , UserManager<ApplicationUser> userManager
            , SignInManager<ApplicationUser> signInManager)
        {
            _logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            

            var homeViewModel = new HomeViewModel
            {
                CarouselItems = new List<CarouselItemViewModel>
                {
                    new CarouselItemViewModel
                    {
                        Title = "Summer Sale",
                        SubTitle = "Up to 50% off on selected items. Limited time offer!",
                        ImageUrl = "https://placehold.co/1200x400/0d6efd/white?text=Summer+Sale",
                        LinkUrl = "sale",
                        ButtonText = "Shop Now",
                        IsActive = true
                    },
                    new CarouselItemViewModel
                    {
                        Title = "New Arrivals",
                        SubTitle = "Check out our latest products for this season.",
                        ImageUrl = "https://placehold.co/1200x400/6610f2/white?text=New+Arrivals",
                        LinkUrl = "new",
                        ButtonText = "Shop Now",
                        IsActive = false
                    },
                    new CarouselItemViewModel
                    {
                        Title = "Free Shipping",
                        SubTitle = "On all orders over $50. Shop now and save!",
                        ImageUrl = "https://placehold.co/1200x400/20c997/white?text=Free+Shipping",
                        LinkUrl = "",  // No specific category
                        ButtonText = "Shop Now",
                        IsActive = false
                    }, 
            },

                FeaturedProducts = new List<ProductViewModel>
                {
                    new ProductViewModel
                    {
                        Id = 1,
                        Name = "Wireless Head Phones",
                        Price = 89.99m,
                        OldPrice = 129.99m,
                        ImageUrl="https://placehold.co/300x300/f8f9fa/0d6efd?text=Wireless+Headphones",
                        Category = "Electronics"
                    },
                    new ProductViewModel
                    {
                        Id = 2,
                        Name = "Samrt Watches",
                        Price = 199.99m,
                        OldPrice = 249.99m,
                        ImageUrl="https://placehold.co/300x300/f8f9fa/0d6efd?text=Smart+Watch",
                        Category = "Electronics"
                    },
                    new ProductViewModel
                    {
                        Id = 3,
                        Name = "Casual T-Shirt",
                        Price = 24.99m,
                        OldPrice = 34.99m,
                        ImageUrl="https://placehold.co/300x300/f8f9fa/0d6efd?text=Casual+T-Shirt",
                        Category = "Clothing"
                    },
                    new ProductViewModel
                    {
                        Id = 4,
                        Name = "Coffee Maker",
                        Price = 59.99m,
                        OldPrice = 79.99m,
                        ImageUrl="https://placehold.co/300x300/f8f9fa/0d6efd?text=Coffee+Maker",
                        Category = "Home & Kiitchen"
                    }
                },

                NewArrivals = new List<ProductViewModel>
                {
                new ProductViewModel
                    {
                        Id = 5,
                        Name = "Premium Headphones",
                        Price = 79.99m,
                        OldPrice = 129.99m,
                        ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Headphones",
                        Category = "Electronics"
                    },
                    new ProductViewModel
                    {
                        Id = 6,
                        Name = "Fitness Smartwatch",
                        Price = 189.99m,
                        OldPrice = 249.99m,
                        ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Smartwatch",
                        Category = "Electronics"
                    },
                    new ProductViewModel
                    {
                        Id = 7,
                        Name = "Designer T-Shirt",
                        Price = 29.99m,
                        OldPrice = 39.99m,
                        ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=T-Shirt",
                        Category = "Clothing"
                    },
                    new ProductViewModel
                    {
                        Id = 8,
                        Name = "Smart Coffee Maker",
                        Price = 69.99m,
                        OldPrice = 89.99m,
                        ImageUrl = "https://placehold.co/300x300/f0f0f0/333333?text=Coffee+Maker",
                        Category = "Home & Kitchen"
                    }
                },

                SpecialOffer = new SpecialOfferViewModel
                 {
                     Title = "Special Offers",
                     SubTitle = "Limited Time Offer",
                     Description = "Get up to 70% of on selected items, limated stock available!",
                     ButtonText = "Shop the Sale",
                     Category = "Sale"            
                 }
            };           
        
            return View(homeViewModel);

        }
                       
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
