namespace StoreApi.Models
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public int? TenderId { get; set; }
        public Tender? Tender { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseBy { get; set; }
    }
}
