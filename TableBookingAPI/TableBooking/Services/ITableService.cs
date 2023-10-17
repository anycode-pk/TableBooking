using Microsoft.AspNetCore.Mvc;
using TableBooking.DTOs;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableBooking.Api.Services;
using TableBooking.DTOs;
using TableBooking.Logic.Interfaces;
using TableBooking.Model;

namespace TableBooking.Api.Services
{
    public interface ITableService
    {
        public Task<IActionResult> GetAllTablesAsync();
        public Task<IActionResult> GetTableByIdAsync(Guid tableId);
        public Task<IActionResult> CreateTableAsync(TableDTO dto);
        public Task<IActionResult> UpdateTableAsync(TableDTO dto);
        public Task<IActionResult> DeleteTableAsync(Guid tableId);
    }

    public class TableService : ITableService
    {
        private IUnitOfWork _unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> CreateTableAsync(TableDTO dto)
        {
            var table = new Table
            {
                NumberOfSeats = dto.NumberOfSeats,
                RestaurantId = dto.RestaurantId
            };
            await _unitOfWork.TableRepository.InsertAsync(table);
            await _unitOfWork.SaveChangesAsync();
            return new OkObjectResult(table);
        }

        public async Task<IActionResult> DeleteTableAsync(Guid tableId)
        {
            var tableToDelete = await _unitOfWork.TableRepository.GetByIdAsync(tableId);
            if (tableToDelete == null)
                return new NotFoundObjectResult($"Restaurant with Id = {tableId} not found");
            await _unitOfWork.TableRepository.Delete(tableToDelete);
            await _unitOfWork.SaveChangesAsync();
            return new OkObjectResult(tableToDelete);
        }

        public async Task<IActionResult> GetAllTablesAsync()
        {
            var tables = await _unitOfWork.TableRepository.GetAllAsync();
            if (tables == null) return new BadRequestObjectResult("No tables found");
            return new OkObjectResult(tables);
        }

        public async Task<IActionResult> GetTableByIdAsync(Guid tableId)
        {
            var table = await _unitOfWork.TableRepository.GetByIdAsync(tableId);
            if (table == null)
                return new BadRequestObjectResult($"Can't find table with {tableId}");
            return new OkObjectResult(table);
        }

        public async Task<IActionResult> UpdateTableAsync(TableDTO dto)
        {
            var table = new Table
            {
                NumberOfSeats = dto.NumberOfSeats,
                RestaurantId = dto.RestaurantId
            };
            await _unitOfWork.TableRepository.Update(table);
            await _unitOfWork.SaveChangesAsync();
            return new OkObjectResult(table);
        }
    }
}
