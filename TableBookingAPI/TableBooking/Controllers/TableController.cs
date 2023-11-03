using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.Model.Dtos.TableDtos;

namespace TableBooking.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private ITableService _tableService;
        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet("GetAllTables")]
        public async Task<IActionResult> GetAllTables()
        {
            return await _tableService.GetAllTablesAsync();
        }

        [HttpGet("GetTable/{id}")]
        public async Task<IActionResult> GetTableById(Guid id)
        {
            return await _tableService.GetTableByIdAsync(id);
        }

        [HttpGet("GetTableByRestaurant")]
        public async Task<IActionResult> GetTableByRestaurantId([FromQuery] Guid restaurantId)
        {
            return await _tableService.GetTableByRestaurantAsync(restaurantId);
        }

        [HttpPost("CreateTable")]
        public async Task<IActionResult> CreateTable([FromBody] TableDto tableDto)
        {
            return await _tableService.CreateTableAsync(tableDto);
        }

        [HttpPut("UpdateTable")]
        public async Task<IActionResult> UpdateTable([FromBody] TableDto tableDto)
        {
            return await _tableService.UpdateTableAsync(tableDto);
        }

        [HttpDelete("DeleteTable/{id:int}")]
        public async Task<IActionResult> DeleteTable(Guid id)
        {
            return await _tableService.DeleteTableAsync(id);
        }
    }
}