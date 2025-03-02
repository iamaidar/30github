using Api.Data;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Dtos.Stock;
using Api.Models;

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
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        Stock stockModel = stockDto.ToStockFromCreateDto();
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto dto)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

        if (stockModel == null)
        {
            return NotFound();
        }

        //         public string Symbol { get; set; } = string.Empty;

        // public string CompanyName { get; set; } = string.Empty;

        // public decimal Purchase { get; set; }

        // public decimal LastDiv { get; set; }

        // public string Industry { get; set; } = string.Empty;

        // public long MarketCap { get; set; }

        stockModel.Symbol = dto.Symbol;
        stockModel.CompanyName = dto.CompanyName;
        stockModel.Purchase = dto.Purchase;
        stockModel.LastDiv = dto.LastDiv;
        stockModel.Industry = dto.Industry;
        stockModel.MarketCap = dto.MarketCap;

        await _context.SaveChangesAsync();

        return Ok(stockModel.ToStockDto());
    }
}
