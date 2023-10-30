using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface ITableService
    {
        public Task<IActionResult> GetAllTablesAsync();
        public Task<IActionResult> GetTableByIdAsync(Guid tableId);
        public Task<IActionResult> CreateTableAsync(TableDTO dto);
        public Task<IActionResult> UpdateTableAsync(TableDTO dto);
        public Task<IActionResult> DeleteTableAsync(Guid tableId);
    }

}
