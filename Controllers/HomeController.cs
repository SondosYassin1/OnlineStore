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
