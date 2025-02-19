using Api.Dtos;
using Api.Dtos.Stock;
using Api.Models;

namespace Api.Mappers;

public static class StockMapper
{
    public static Dtos.Stock.StockDto ToStockDto(this Stock stockModel) {
        return new StockDto{
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            LastDiv = stockModel.LastDiv,
            MarketCap = stockModel.MarketCap
        };
    }
}
