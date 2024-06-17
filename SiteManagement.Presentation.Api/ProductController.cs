using Microsoft.AspNetCore.Mvc;
using SiteQuery_Ado.Contracts;
using SiteQuery_Ado.Models;

namespace SiteManagement.Presentation.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery _productQuery;

        public ProductController(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        [HttpGet]
        public async Task<List<ProductQueryModel>> GetLatestArrivals(CancellationToken cancellationToken)
        {
            return await _productQuery.GetLatestArrivals(cancellationToken);
        }
    }
}
