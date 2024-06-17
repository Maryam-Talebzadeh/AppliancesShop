using IM.Domain.Core.InventoryAgg.AppServices;
using IM.Domain.Core.InventoryAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryAppService _inventoryAppService;

        public InventoryController(IInventoryAppService inventoryAppService)
        {
            _inventoryAppService = inventoryAppService;
        }

        [HttpGet("{id}")]
        public async Task<List<InventoryOperationDTO>> GetOperationsBy(long id, CancellationToken cancellationToken)
        {
            return await _inventoryAppService.GetOperationLog(id, cancellationToken);
        }

        [HttpPost]
        public async Task<StockStatusDTO> CheckStock(IsInStockDTO command, CancellationToken cancellationToken)
        {
            return await _inventoryAppService.CheckStock(command, cancellationToken);
        }
    }
}
