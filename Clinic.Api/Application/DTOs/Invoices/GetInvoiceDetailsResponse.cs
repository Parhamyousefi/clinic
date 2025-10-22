namespace Clinic.Api.Application.DTOs.Invoices
{
    public class GetInvoiceDetailsResponse
    {
        public int SystemCode { get; set; }
        public string InvoiceNo { get; set; }
        public string? BussinessName { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal Receipt { get; set; }
        public decimal Payment { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime? VisitTime { get; set; }
        public string? DoctorName { get; set; }
    }
}
