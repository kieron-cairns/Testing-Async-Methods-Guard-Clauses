using TestingAsyncMethodsGuardClauses.Models;

namespace TestingAsyncMethodsGuardClauses.Repositories
{
    public class StockRepository : IStockRepository
    {


        public static List<StockItem> items = new List<StockItem>
        {
            new StockItem{ Id = 1, Name = "MacBook Pro 13inch M1", Quantity = 10, Price = 1200.0 },
            new StockItem{ Id = 2, Name = "MacBook Pro 16inch M1", Quantity = 10, Price = 1600.0 }
        };

        public async Task<List<StockItem>> GetStockItemById(int id)
        {
            var item = items.Where(x => x.Id == id).ToList();

            return item;

        }
    }
}
