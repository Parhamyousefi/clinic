namespace Clinic.Api.Application.DTOs.Treatments
{
    public class GetServicesPerPatientResponse
    {
        public int InvoiceId { get; set; }
        public int InvoiceItemId { get; set; }
        public int? TreatmentTemplateId { get; set; }
        public string? BillableItemName { get; set; }
        public decimal? BillableItemPrice { get; set; }
        public int? ItemCategoryId { get; set; }
        public string? ItemCategoryName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal Amount { get; set; }
    }
}
