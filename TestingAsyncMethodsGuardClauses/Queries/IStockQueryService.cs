using TestingAsyncMethodsGuardClauses.Models;

namespace TestingAsyncMethodsGuardClauses.Queries
{
    public interface IStockQueryService
    {
        Task<List<StockItem>> GetStockItemById(string id);
    }
}
