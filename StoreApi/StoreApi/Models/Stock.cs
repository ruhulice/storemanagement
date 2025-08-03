namespace StoreApi.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int StockQuantity { get; set; }
        public int? ReorderLevel { get; set; }
        public int? BlockedQuantity { get; set; }

    }
}
