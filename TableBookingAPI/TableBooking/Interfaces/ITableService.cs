using Microsoft.AspNetCore.Mvc;
using TableBooking.Model.Dtos.TableDtos;

namespace TableBooking.Api.Interfaces
{
    public interface ITableService
    {
        public Task<IActionResult> GetAllTablesAsync();
        public Task<IActionResult> GetTableByIdAsync(Guid tableId);
        public Task<IActionResult> CreateTableAsync(TableDto dto);
        public Task<IActionResult> UpdateTableAsync(TableDto dto);
        public Task<IActionResult> DeleteTableAsync(Guid tableId);
    }

}
