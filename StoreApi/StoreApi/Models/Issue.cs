namespace StoreApi.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public int RequisitionId { get; set; }
        public Requisition Requisition { get; set; }
        public int IssedQuantity { get; set; }
        public required string UOM { get; set; }
        public DateTime IssuedDate { get; set; }
        public int IssuedToId { get; set; }
        public Employee Employee { get; set; }
        public int? ReceivedById { get; set; }
        public DateTime? ReceivedDate { get; set; }

    }
}
