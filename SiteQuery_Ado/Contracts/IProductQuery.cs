
using SiteQuery_Ado.Models;

namespace SiteQuery_Ado.Contracts
{
    public interface IProductQuery
    {
        ProductQueryModel GetProductDetails(string slug);
    }
}
