

namespace SM.Domain.Core.OrderAgg.DTOs.Order
{
   public class CartDTO
    {
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public int PaymentMethod { get; set; }
        public List<CartItemDTO> Items { get; set; }

        public CartDTO()
        {
            Items = new List<CartItemDTO>();
        }

        public void Add(CartItemDTO cartItem)
        {
            Items.Add(cartItem);
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;
        }

        public void SetPaymentMethod(int methodId)
        {
            PaymentMethod = methodId;
        }
    }
}
