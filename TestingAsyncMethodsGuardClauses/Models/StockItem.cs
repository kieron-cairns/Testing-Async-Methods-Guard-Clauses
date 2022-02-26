namespace TestingAsyncMethodsGuardClauses.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public double Price { get; set; }  
    }
}
