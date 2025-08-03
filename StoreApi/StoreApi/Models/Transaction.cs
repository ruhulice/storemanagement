namespace StoreApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TransactionTypeById { get; set; }
        public int Quantity { get; set; }
        public string UOM { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Comments { get; set; }
    }
}
