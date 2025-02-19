using Api.Models.Stock;
using Api.Dtos;

namespace Api.Mappers;

public static class StockMapper
{
    public static StockDto ToStockDto(this Stock stockModel) {
        return new StockDto{
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockmodel.Purchase,
            LastDiv = stockModel.LastDiv,
            MarketCap = stockModel.MarketCap
        };
    }
}
