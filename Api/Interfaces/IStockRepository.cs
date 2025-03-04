using Api.Models;

namespace Api.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync();
}