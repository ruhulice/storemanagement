namespace StoreApi.DTOs
{
    public class RequisitionDto
    {
        public int Id { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int? EmployeeId { get; set; }
        public string? Employee { get; set; }
        public int StatusId { get; set; }
        public string? Status { get; set; }
        public int RequisitionId { get; set; }
        public string? Requisition { get; set; }
        public int ProductId { get; set; }
        public string? Product { get; set; }
        public int RequestedQuantity { get; set; }
        public string UOM { get; set; }
    }
}
