using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.ViewComponents
{
    public class CartItemCountViewComponent : ViewComponent
    {
        public CartItemCountViewComponent() { }
         
        public Task<IViewComponentResult> InvokeAsynce()
        {
            int cartItemCount = 0;
            return Task.FromResult<IViewComponentResult>(
                Content(cartItemCount.ToString()));
        }
    }
}
