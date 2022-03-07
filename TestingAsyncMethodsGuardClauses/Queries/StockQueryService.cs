using TestingAsyncMethodsGuardClauses.Models;
using TestingAsyncMethodsGuardClauses.Repositories;

namespace TestingAsyncMethodsGuardClauses.Queries
{
    public class StockQueryService : IStockQueryService
    {
        private readonly IStockRepository stockRepository;

        

        public StockQueryService(IStockRepository stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public async Task<List<StockItem>> GetStockItemById(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            return await this.stockRepository.GetStockItemById(id);
        }
    }
}
