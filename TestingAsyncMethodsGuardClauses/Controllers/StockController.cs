using Microsoft.AspNetCore.Mvc;
using TestingAsyncMethodsGuardClauses.Models;
using TestingAsyncMethodsGuardClauses.Queries;

namespace TestingAsyncMethodsGuardClauses.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockQueryService stockQueryService;

        public StockController(IStockQueryService stockQueryService)
        {
            this.stockQueryService = stockQueryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<StockItem>>> Get(int id)
        {
            var result = await this.stockQueryService.GetStockItemById(id);

            return new OkObjectResult(result);
        }
    }
}
