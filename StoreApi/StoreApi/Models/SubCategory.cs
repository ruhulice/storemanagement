namespace StoreApi.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public required string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
