namespace StoreApi.Models
{
    public class Requisition
    {
        public int Id { get; set; }
        public DateTime RequisitionDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
