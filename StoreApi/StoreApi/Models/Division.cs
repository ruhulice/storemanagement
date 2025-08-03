namespace StoreApi.Models
{
    public class Division
    {
        public int Id { get; set; }
        public required string DivisionName { get; set; }
        public string? FullDiv { get; set; }
    }
}
