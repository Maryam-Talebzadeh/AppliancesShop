using Base_Framework.Domain.Core.Contracts;
using Base_Framework.Domain.Core.Contracts.ZarinPal;
using Base_Framework.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;
using SM.Domain.Core.OrderAgg.AppServices;
using SM.Domain.Core.OrderAgg.DTOs.Order;
using SM.Domain.Core.OrderAgg.Services;
using System.Globalization;

namespace ServiceHost.RazorPages.Pages
{
    public class CheckoutModel : PageModel
    {
        public CartDTO Cart;
        public const string CookieName = "cart-items";
        private readonly ICartCalculatorService _cartCalculatorService;
        private readonly IAuthHelper _authHelper;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IOrderAppService _orderAppService;
        private readonly IZarinPalFactory _zarinPalFactory;

        public CheckoutModel(ICartCalculatorService cartCalculatorService, IAuthHelper authHelper, ICartService cartService,
            IProductQuery productQuery, IOrderAppService orderAppService, IZarinPalFactory zarinPalFactory)
        {
            Cart = new CartQueryModel();
            _cartCalculatorService = cartCalculatorService;
            _authHelper = authHelper;
            _cartService = cartService;
            _productQuery = productQuery;
            _orderAppService = orderAppService;
            _zarinPalFactory = zarinPalFactory;
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


        public async Task<IActionResult> OnPostPay(int paymentMethod, CancellationToken cancellationToken)
        {
            var cart =await _cartService.Get(cancellationToken);
            cart.SetPaymentMethod(paymentMethod);

            var result = await _productQuery.CheckInventoryStatus(cart.Items, cancellationToken );
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = await _orderAppService.PlaceOrder(cart, cancellationToken);
            if (paymentMethod == 1)
            {
                var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                    cart.PayAmount.ToString(CultureInfo.InvariantCulture), "", "",
                   ApplicationMessages.PaymentResponse, orderId);

                return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
            }

            var paymentResult = new PaymentResult();
            return RedirectToPage("PaymentResult",
                paymentResult.Succeeded(
                    ApplicationMessages.OrderSucceded, null));
        }

        public async  Task<IActionResult> OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId, CancellationToken cancellationToken)
        {
            var orderAmount = await _orderAppService.GetAmountBy(oId, cancellationToken);
            var verificationResponse =
                _zarinPalFactory.CreateVerificationRequest(authority,
                    orderAmount.ToString(CultureInfo.InvariantCulture));

            var result = new PaymentResult();
            if (status == "OK" && verificationResponse.Status >= 100)
            {
                var issueTrackingNo =await _orderAppService.PaymentSucceeded(oId, verificationResponse.RefID, cancellationToken);
                Response.Cookies.Delete("cart-items");
                result = result.Succeeded(ApplicationMessages.PaymentSucceded, issueTrackingNo);
                return RedirectToPage("/PaymentResult", result);
            }

            result = result.Failed(
              ApplicationMessages.PaymentFailed);
            return RedirectToPage("/PaymentResult", result);
        }
    }
}
