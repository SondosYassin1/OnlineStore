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

            // Tested the partial view

            //tested Signin
            //    var email = "test@example.com";
            //    var userName = email;
            //    var tempPassword = "Test123!";

            //    var user = await userManager.FindByEmailAsync(email); // will only be stisfied the await ,if the index is task and async
            //    if (user == null)
            //    {
            //        user = new ApplicationUser
            //        {
            //            UserName = userName,
            //            Email = email,
            //            EmailConfirmed = true
            //        };

            //        var result = await userManager.CreateAsync(user, tempPassword);

            //        if (!result.Succeeded)
            //        {
            //            return View();
            //        }
            //    }
            //await signInManager.SignInAsync(user, isPersistent: false);

            //tested Signout 
            //await signInManager.SignOutAsync();

<<<<<<< Updated upstream
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            var homeViewModel = new HomeViewModel
            {
                CarouselItems = GetCarouselItems(),
                FeaturedProducts = GetFeaturedProducts(),
                NewArrivals = GetNewArrivals(),
                SpecialOffer = GetSpecialOffer(),
                Categorys = GetCategorys(),
                Testimonials = GetTestimonials(),
                CallToAction = GetCallToAction()
            };           
        
            return View(homeViewModel);

        }
         
        private List<CarouselItemViewModel> GetCarouselItems()
        {
                return  new List<CarouselItemViewModel>
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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                    }
                };
=======
=======
>>>>>>> Stashed changes
                    }, 
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
<<<<<<< Updated upstream
=======
        
            return View(homeViewModel);
        }
                       
>>>>>>> Stashed changes
        
            return View(homeViewModel);
>>>>>>> Stashed changes
        }
        
        private List<ProductViewModel> GetFeaturedProducts()
        {
            return new List<ProductViewModel>
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
                };
        }

        private List<ProductViewModel> GetNewArrivals()
        {
            return new List<ProductViewModel>
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
                };
        }
        private SpecialOfferViewModel GetSpecialOffer()
        {
            return new SpecialOfferViewModel
            {
                Title = "Special Offers",
                SubTitle = "Limited Time Offer",
                Description = "Get up to 70% of on selected items, limated stock available!",
                ButtonText = "Shop the Sale",
                Category = "Sale"
            };
        }
        private List<CategoryViewModel> GetCategorys()
        {
            return new List<CategoryViewModel>
            {
                new CategoryViewModel
                {
                    CategoryId = 1,
                    Name = "Electronics",
                    Slug = "electronics",
                    IconClass = "fas fa-laptop",
                    Description = "The latest gadgets and tech innovations."
                },
                new CategoryViewModel
                {
                    CategoryId = 2,
                    Name = "Clothing",
                    Slug = "clothing",
                    IconClass = "fas fa-tshirt",
                    Description = "Fashionable apparel for all ages."
                },
                new CategoryViewModel
                {
                    CategoryId = 3,
                    Name = "Home & Kitchen",
                    Slug = "home",
                    IconClass = "fas fa-home",
                    Description = "Everything you need for your home."
                }
            };
        }
        private List<TestimonialViewModel> GetTestimonials()
        {
            return new List<TestimonialViewModel>
            {
                new TestimonialViewModel
                {
                    Id = 1,
                    CustomerName = "John Doe",
                    Comment = "Excellent service and fast delivery. The products are of high quality and exactly as described. Will definitely shop here again!",
                    Rating = 5.0m,
                    ImageUrl = "https://placehold.co/50x50/6c757d/white?text=JD"
                },
                new TestimonialViewModel
                {
                    Id = 2,
                    CustomerName = "Jane Smith",
                    Comment = "I'm impressed with the quality of the products. The customer service was very helpful when I had questions about my order.",
                    Rating = 4.5m,
                    ImageUrl = "https://placehold.co/50x50/6c757d/white?text=JS"
                },
                new TestimonialViewModel
                {
                    Id = 3,
                    CustomerName = "Robert Johnson",
                    Comment = "Fast shipping and the product exceeded my expectations. The online shopping experience was seamless from start to finish.",
                    Rating = 5.0m,
                    ImageUrl = "https://placehold.co/50x50/6c757d/white?text=RJ"
                }
            };
        }
        private CallToActionViewModel GetCallToAction()
        {
            return new CallToActionViewModel
            {               
                Title = "Ready to start shopping",
                Description = "Explore our wide range of products and find exactly what you're looking for.",
                ButtonText = "Shop Now",
                ControllerName = "Products",
                ActionName = "Index"
            };
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
