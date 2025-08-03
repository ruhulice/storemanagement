namespace StoreApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string UOM { get; set; }
        public string? Description { get; set; }
        // Foreign key subcategory
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }


    }
}
