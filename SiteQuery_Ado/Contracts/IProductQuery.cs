
using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductQuery
    {
        Task<ProductQueryModel> GetDetails(string slug, CancellationToken cancellationToken);
        public Task<List<ProductQueryModel>> GetLatestArrivals( CancellationToken cancellationToken);
        public Task<List<ProductQueryModel>> Search(string value, CancellationToken cancellationToken);
        Task<ProductPictureQueryModel> GetFirstPictureByProductId(long id, CancellationToken cancellationToken);
    }
}
