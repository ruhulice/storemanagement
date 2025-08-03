namespace StoreApi.Models
{
    public class RequisitionDetails
    {
        public int Id { get; set; }
        public int RequisitionId { get; set; }
        public Requisition Requisition { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int RequestedQuantity { get; set; }
        public required string UOM { get; set; }
    }
}
