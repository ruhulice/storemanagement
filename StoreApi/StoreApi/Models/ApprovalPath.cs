namespace StoreApi.Models
{
    public class ApprovalPath
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int ApprovalTemplateId { get; set; }
        public ApprovalTemplate ApprovalTemplate { get; set; }
    }
}
