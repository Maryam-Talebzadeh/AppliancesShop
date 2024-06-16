

namespace SiteQuery_Ado.Models
{
    public class CartQueryModel
    {
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public int PaymentMethod { get; set; }
        public List<CartItemQueryModel> Items { get; set; }

        public CartQueryModel()
        {
            Items = new List<CartItemQueryModel>();
        }

        public void Add(CartItemQueryModel cartItem)
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
