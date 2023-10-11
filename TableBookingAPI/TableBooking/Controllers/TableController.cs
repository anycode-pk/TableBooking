using Microsoft.AspNetCore.Mvc;
using TableBooking.Api.Interfaces;
using TableBooking.DTOs;

namespace TableBooking.Controllers;

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

    [HttpGet("GetTableById/{id}")]
    public async Task<IActionResult> GetTableById(int id)
    {
        return await _tableService.GetTableByIdAsync(id);
    }
        
    [HttpPost("CreateTable")]
    public async Task<IActionResult> CreateTable([FromBody] TableDTO tableDto)
    {
        return await _tableService.CreateTableAsync(tableDto);
    }

    [HttpPut("UpdateTable")]
    public async Task<IActionResult> UpdateTable([FromBody] TableDTO tableDto)
    {
        return await _tableService.UpdateTableAsync(tableDto);
    }

    [HttpDelete("DeleteTable/{id:int}")] 
    public async Task<IActionResult> DeleteTable(int id)
    {
        return await _tableService.DeleteTableAsync(id);
    }
}