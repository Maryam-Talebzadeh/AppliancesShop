using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.Core.InventoryAgg.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;

namespace ServiceHost.RazorPages.Areas.Administration.Pages.Inventory.InventoryAgg
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public SearchInventoryDTO SearchModel;
        public List<InventoryDTO> Inventory;
        public SelectList Products;

        private readonly IProductAppService _productAppService;
        private readonly IInventoryAppService _inventoryAppService;

        public IndexModel(IProductAppService productApplication, IInventoryAppService inventoryApplication)
        {
            _productAppService = productApplication;
            _inventoryAppService = inventoryApplication;
        }

        public void OnGet(SearchInventoryDTO searchModel)
        {
            Products = new SelectList(_productAppService.GetProducts(), "Id", "Name");
            Inventory = _inventoryAppService.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventoryDTO
            {
                Products = _productAppService.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateInventoryDTO command)
        {
            var result = _inventoryAppService.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryAppService.GetDetails(id);
            inventory.Products = _productAppService.GetProducts();
            return Partial("Edit", inventory);
        }

        public JsonResult OnPostEdit(EditInventoryDTO command)
        {
            var result = _inventoryAppService.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

        public JsonResult OnPostIncrease(IncreaseInventoryDTO command)
        {
            var result = _inventoryAppService.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }

        public JsonResult OnPostReduce(ReduceInventoryDTO command)
        {
            var result = _inventoryAppService.Reduce(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log = _inventoryAppService.GetOperationLog(id);
            return Partial("OperationLog", log);
        }
    }
}
