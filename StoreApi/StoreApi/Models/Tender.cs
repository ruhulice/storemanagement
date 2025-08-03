namespace StoreApi.Models
{
    public class Tender
    {
        public int Id { get; set; }
        public string TanderName { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
