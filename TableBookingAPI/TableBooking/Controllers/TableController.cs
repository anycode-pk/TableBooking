using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TableBooking.DTOs;
using TableBooking.EF;
using TableBooking.Model;
using Table = TableBooking.Model.Table;

namespace TableBooking.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableController : ControllerBase
{
    private readonly DataContext _context;
    public TableController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAllTables()
    {
        var tables = _context.Tables.ToList();
        return Ok(tables);
    }

    [HttpGet("{id}")]
    public IActionResult GetTableById(int id)
    {
        var table = _context.Tables.Find(id);
        if (table == null)
            return new BadRequestObjectResult($"Can't find table with {id}");
        return Ok(table);
    }
        
    [HttpPost]
    public async Task<IActionResult> AddTable([FromBody] TableDTO tableDto)
    {
        var table = new Table
        {
            NumberOfSeats = tableDto.NumberOfSeats,
            RestaurantId = tableDto.RestaurantId
        };
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();
        return Ok(table);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTable(int id, [FromBody] TableDTO tableDto)
    {
        var table = new Table
        {
            NumberOfSeats = tableDto.NumberOfSeats,
            RestaurantId = tableDto.RestaurantId
        };
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();
        return Ok(table);
    }

    [HttpDelete("{id:int}")] 
    public async Task<IActionResult> DeleteTable(int id)
    {
        var tableToDelete = _context.Tables.Find(id);
        if (tableToDelete == null)
            return NotFound($"Restaurant with Id = {id} not found");
        _context.Tables.Remove(tableToDelete);
        _context.SaveChanges();
        return Ok(tableToDelete);
    }
}