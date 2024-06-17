using Base_Framework.Domain.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Services;

namespace ServiceHost.RazorPages.Pages
{
    public class CheckoutModel : PageModel
    {
        public CartQueryModel Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly IAuthHelper _authHelper;
        private readonly ICartService _cartService;

        public CheckoutModel(ICartCalculatorService cartCalculatorService, IAuthHelper authHelper, ICartService cartService)
        {
            Cart = new CartQueryModel();
            _cartCalculatorService = cartCalculatorService;
            _authHelper = authHelper;
            _cartService = cartService;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItemQueryModel>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart =await  _cartCalculatorService.ComputeCart(cartItems, cancellationToken, _authHelper);
            var cart = new CartDTO()
            {
                DiscountAmount = Cart.DiscountAmount,
                PayAmount = Cart.PayAmount,
                PaymentMethod = Cart.PaymentMethod,
                TotalAmount = Cart.TotalAmount,
                Items = Cart.Items.Select(item =>
                new CartItemDTO()
                {
                    Count = item.Count,
                    DiscountAmount = item.DiscountAmount,
                    DiscountRate = item.DiscountRate,
                    Id = item.Id,
                    IsInStock = item.IsInStock,
                    ItemPayAmount = item.ItemPayAmount,
                    Name = item.Name,
                    Picture = item.Picture,
                    TotalItemPrice = item.UnitPrice,
                    UnitPrice = item.UnitPrice
                }).ToList()
            };
            await _cartService.Set(cart, cancellationToken);
        }
    }
}
