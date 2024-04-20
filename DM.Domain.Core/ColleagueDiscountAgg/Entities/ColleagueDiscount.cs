using Base_Framework.Domain.Core.Entities;

namespace DM.Domain.Core.ColleagueDiscountAgg.Entities
{
    public class ColleagueDiscount : BaseEntity
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }

        public ColleagueDiscount(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

        public void Edit(long productId, int discountRate)
        {
            ProductId = productId;
            DiscountRate = discountRate;
        }

    }
}
