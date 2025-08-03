namespace StoreApi.DTOs
{
    public class StockDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string? Product { get; set; }
        public int StockQuantity { get; set; }
        public int? ReorderLevel { get; set; }
        public int? BlockedQuantity { get; set; }
        public string? UOM { get; set; }
    }
}
