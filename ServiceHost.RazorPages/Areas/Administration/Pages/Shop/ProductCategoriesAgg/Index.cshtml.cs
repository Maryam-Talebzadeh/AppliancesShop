using Base_Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SM.Domain.Core.ProductCategoryAgg.AppServices;
using SM.Domain.Core.ProductCategoryAgg.DTOs;
using SM.Infrastructure.Configuration.Permissions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Shop.ProductCategoriesAgg
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryAppService _productCategoryAppService;

        public List<ProductCategoryViewModel> ProductCategories;
        public SearchProductCategoryDTO SearchModel;

        public IndexModel(IProductCategoryAppService productCategoryAppService)
        {
            _productCategoryAppService = productCategoryAppService;
        }

        [NeedsPermission(ShopPermissions.ListProductCategories)]
        public void OnGet(SearchProductCategoryDTO search)
        {
            ProductCategories = _productCategoryAppService.Search(search);
        }

        [NeedsPermission(ShopPermissions.CreateProductCategory)]
        public ActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategoryViewModel());
        }

        [NeedsPermission(ShopPermissions.CreateProductCategory)]
        public JsonResult OnPostCreate(CreateProductCategoryViewModel command)
        {
            var result = _productCategoryAppService.Create(command);
            return new JsonResult(result);
        }

        [NeedsPermission(ShopPermissions.EditProductCategory)]
        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryAppService.GetDetail(id);

            return Partial("Edit", productCategory);
        }

        [NeedsPermission(ShopPermissions.EditProductCategory)]
        public JsonResult OnPostEdit(EditProductCategoryViewModel command)
        {
            var result = _productCategoryAppService.Edit(command);
            return new JsonResult(result);
        }

    }
}
