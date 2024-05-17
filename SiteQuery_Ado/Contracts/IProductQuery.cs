
using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductQuery
    {
        public List<ProductQueryModel> GetLatestArrivals();
        public List<ProductQueryModel> Search(string value);
    }
}
