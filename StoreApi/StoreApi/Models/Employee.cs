namespace StoreApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string EmployeeInitial { get; set; }
        public required string FullName { get; set; }
        public string? MobileNo { get; set; }
        public required string EmialAddress { get; set; }
        public int EmploymentStatusId { get; set; }
        public int DivisionId { get; set; }
        public Division Division { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
    }
}
