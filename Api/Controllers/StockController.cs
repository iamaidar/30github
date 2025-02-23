using Api.Data;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StockController(ApplicationDbContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stocks = (await _context.Stocks.ToListAsync()).Select(s => s.ToStockDto());

        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id) 
    {
        var stock = (await _context.Stocks.FindAsync(id)).ToStockDto();

        if (stock == null) 
        {
            return NotFound();
        }

        return Ok(stock);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto) {
        var stockModel = stockDto.ToStockFromCreateDto();
        await _context.Stocks.Add(stockModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
    }
}
