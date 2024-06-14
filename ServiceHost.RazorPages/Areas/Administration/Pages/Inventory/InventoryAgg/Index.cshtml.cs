using Base_Framework.Infrastructure;
using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.Core.InventoryAgg.DTOs;
using IM.Infrastructure.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SM.Domain.Core.ProductAgg.AppSevices;
using SM.Infrastructure.Configuration.Permissions;

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

        [NeedsPermission(InventoryPermissions.ListInventory)]
        public async Task OnGet(SearchInventoryDTO searchModel, CancellationToken cancellationToken)
        {
            Products = new SelectList(await _productAppService.GetProducts(cancellationToken), "Id", "Name");
            Inventory = await _inventoryAppService.Search(searchModel, cancellationToken);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public async Task<IActionResult> OnGetCreate(CancellationToken cancellationToken)
        {
            var command = new CreateInventoryDTO
            {
                Products = await _productAppService.GetProducts(cancellationToken)
            };
            return Partial("./Create", command);
        }

        [NeedsPermission(InventoryPermissions.CreateInventory)]
        public async Task<JsonResult> OnPostCreate(CreateInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Create(command, cancellationToken);
            return new JsonResult(result);
        }

        [NeedsPermission(InventoryPermissions.EditInventory)]
        public async Task<IActionResult> OnGetEdit(long id, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryAppService.GetDetails(id, cancellationToken);
            inventory.Products = await _productAppService.GetProducts(cancellationToken);
            return Partial("Edit", inventory);
        }

        [NeedsPermission(InventoryPermissions.EditInventory)]
        public async Task<JsonResult> OnPostEdit(EditInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Edit(command, cancellationToken);
            return new JsonResult(result);
        }

        [NeedsPermission(InventoryPermissions.Increase)]
        public async Task<IActionResult> OnGetIncrease(long id, CancellationToken cancellationToken)
        {
            var command = new IncreaseInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }

        [NeedsPermission(InventoryPermissions.Increase)]
        public async Task<JsonResult> OnPostIncrease(IncreaseInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Increase(command, cancellationToken);
            return new JsonResult(result);
        }

        [NeedsPermission(InventoryPermissions.Reduce)]
        public async Task<IActionResult> OnGetReduce(long id, CancellationToken cancellationToken)
        {
            var command = new ReduceInventoryDTO()
            {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }

        [NeedsPermission(InventoryPermissions.Reduce)]
        public async Task<JsonResult> OnPostReduce(ReduceInventoryDTO command, CancellationToken cancellationToken)
        {
            var result = await _inventoryAppService.Reduce(command, cancellationToken);
            return new JsonResult(result);
        }

        [NeedsPermission(InventoryPermissions.OperationLog)]
        public async Task<IActionResult> OnGetLog(long id, CancellationToken cancellationToken)
        {
            var log = await _inventoryAppService.GetOperationLog(id, cancellationToken);
            return Partial("OperationLog", log);
        }
    }
}
