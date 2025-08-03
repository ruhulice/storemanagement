namespace StoreApi.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string UOM { get; set; }
        public string? Description { get; set; }
        public int SubCategoryId { get; set; }


    }
}
