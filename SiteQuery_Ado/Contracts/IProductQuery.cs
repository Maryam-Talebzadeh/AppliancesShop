using SiteQuery_Ado.Models;
using SM.Domain.Core.OrderAgg.DTOs.Order;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductQuery
    {
        Task<ProductQueryModel> GetDetails(string slug, CancellationToken cancellationToken);
        public Task<List<ProductQueryModel>> GetLatestArrivals( CancellationToken cancellationToken);
        public Task<List<ProductQueryModel>> Search(string value, CancellationToken cancellationToken);
        Task<ProductPictureQueryModel> GetFirstPictureByProductId(long id, CancellationToken cancellationToken);
        Task<List<CartItemDTO>> CheckInventoryStatus(List<CartItemDTO> cartItems, CancellationToken cancellationToken);
    }
}
