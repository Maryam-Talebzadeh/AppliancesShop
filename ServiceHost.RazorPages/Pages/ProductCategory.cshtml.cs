using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public async Task OnGet(string id, CancellationToken cancellationToken)
        {
            ProductCategory = await _productCategoryQuery.GetProductCategoryWithProducstsBy(id, cancellationToken);
        }
    }
}
