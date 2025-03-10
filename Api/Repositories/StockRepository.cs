using Api.Data;
using Api.Dtos.Stock;
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

        public Task<Stock> CreateAsync(Stock stockModel)
        {
            throw new NotImplementedException();
        }

        public Task<Stock?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}