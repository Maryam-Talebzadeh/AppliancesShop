using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace ServiceHost.RazorPages.Pages
{
    public class SearchModel : PageModel
    {
            public string Value;
            public List<ProductQueryModel> Products;
            private readonly IProductQuery _productQuery;

            public SearchModel(IProductQuery productQuery)
            {
                _productQuery = productQuery;
            }

            public void OnGet(string value)
            {
                Value = value;
                Products = _productQuery.Search(value);
            }
        
    }
}

