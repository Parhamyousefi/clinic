namespace Clinic.Api.Application.DTOs.Invoices
{
    public class GetReciptsResponse
    {
        public int Id { get; set; }
        public int? ReceiptNo { get; set; }
        public int PatientId { get; set; }
        public decimal? Cash { get; set; }
        public decimal? EFTPos { get; set; }
        public decimal? Other { get; set; }
        public string? Notes { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool AllowEdit { get; set; }
        public int? CreatorId { get; set; }
        public int ReceiptTypeId { get; set; }
        public string? PatientName { get; set; }
    }
}
