namespace Clinic.Api.Domain.Entities
{
    public class InvoiceItemHistoriesContext
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public decimal OldQty { get; set; }
        public decimal NewQty { get; set; }
        public int PatientId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
