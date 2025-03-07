using Api.Dtos.Stock;
using Api.Models;

namespace Api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto dto);
    Task<Stock?> DeleteAsync(int id);
}