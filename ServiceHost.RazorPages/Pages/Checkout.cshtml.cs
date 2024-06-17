using Base_Framework.Domain.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.Pages
{
    public class CheckoutModel : PageModel
    {
        public CartQueryModel Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly IAuthHelper _authHelper;

        public CheckoutModel(ICartCalculatorService cartCalculatorService, IAuthHelper authHelper)
        {
            Cart = new CartQueryModel();
            _cartCalculatorService = cartCalculatorService;
            _authHelper = authHelper;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItemQueryModel>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart =await  _cartCalculatorService.ComputeCart(cartItems, cancellationToken, _authHelper);
        }
    }
}
