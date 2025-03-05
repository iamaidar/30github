using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }
    }
}