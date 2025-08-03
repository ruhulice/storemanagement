namespace StoreApi.Models
{
    public class ApprovalFlow
    {
        public int Id { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int DocumentId { get; set; }
        public int TransactionId { get; set; }
        public string? ProjectNo { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime StatusDate { get; set; }
        public int ApprovalPathId { get; set; }
        public ApprovalPath ApprovalPath { get; set; }
        public int FromAuthorId { get; set; }
        public int ToAuthorId { get; set; }
        public string Comments { get; set; }
        public bool isCurrentFlow { get; set; }
    }
}
