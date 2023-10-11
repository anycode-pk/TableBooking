using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;

namespace TableBooking.Api.Interfaces
{
    public interface ITableService
    {
        public Task<IActionResult> GetAllTablesAsync();
        public Task<IActionResult> GetTableByIdAsync(int tableId);
        public Task<IActionResult> CreateTableAsync(TableDTO dto);
        public Task<IActionResult> UpdateTableAsync(TableDTO dto);
        public Task<IActionResult> DeleteTableAsync(int tableId);
    }
}
