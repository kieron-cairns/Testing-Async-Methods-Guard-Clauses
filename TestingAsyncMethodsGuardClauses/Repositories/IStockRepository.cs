﻿using TestingAsyncMethodsGuardClauses.Models;

namespace TestingAsyncMethodsGuardClauses.Repositories
{
    public interface IStockRepository
    {
        Task<List<StockItem>> GetStockItemById(int id);
    }
}
