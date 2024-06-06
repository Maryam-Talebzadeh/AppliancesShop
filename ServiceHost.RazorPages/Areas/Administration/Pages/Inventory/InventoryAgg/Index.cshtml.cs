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

        public async Task OnGet(SearchInventoryDTO searchModel, CancellationToken cancellationToken)
        {
            Products = new SelectList(await _productAppService.GetProducts(cancellationToken), "Id", "Name");
            Inventory = await _inventoryAppService.Search(searchModel, cancellationToken);
        }

        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new CreateInventoryDTO
            {
                Products = await _productAppService.GetProducts(cancellationToken)
            };
            return Partial("./Create", command);
        }

        public async Task<JsonResult> OnPostCreate(CreateInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Create(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryAppService.GetDetails(id, cancellationToken);
            inventory.Products = await _productAppService.GetProducts(cancellationToken);
            return Partial("Edit", inventory);
        }

        public async Task<JsonResult> OnPostEdit(EditInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetIncrease(long id, CancellationToken cancellationToken)
        {
            var command = new IncreaseInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

        public async Task<JsonResult> OnPostIncrease(IncreaseInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Increase(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetReduce(long id, CancellationToken cancellationToken)
        {
            var command = new ReduceInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }

        public async Task<JsonResult> OnPostReduce(ReduceInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Reduce(command, cancellationToken);
            return new JsonResult(result);
        }

        public async Task<IActionResult> OnGetLog(long id, CancellationToken cancellationToken)
        {
            var log = await _inventoryAppService.GetOperationLog(id, cancellationToken);
            return Partial("OperationLog", log);
        }
    }
}
