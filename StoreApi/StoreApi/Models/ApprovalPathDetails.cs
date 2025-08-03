namespace StoreApi.Models
{
    public class ApprovalPathDetails
    {
        public int Id { get; set; }
        public int ApprovalPathId { get; set; }
        public ApprovalPath ApprovalPath { get; set; }
        public int StepOrder { get; set; }
        public string StepName { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
