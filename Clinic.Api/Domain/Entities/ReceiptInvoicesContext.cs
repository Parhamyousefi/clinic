namespace Clinic.Api.Domain.Entities
{
    public class ReceiptInvoicesContext
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
