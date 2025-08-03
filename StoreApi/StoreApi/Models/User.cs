namespace StoreApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool isActive { get; set; }
        public string? IUser { get; set; }
        public DateTime? IDate { get; set; }
        public string? EUser { get; set; }
        public DateTime? EDate { get; set; }

    }
}
