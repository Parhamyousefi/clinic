namespace Clinic.Api.Application.DTOs.Report
{
    public class InvoiceByClinicResponse
    {
        public int ClinicId { get; set; }
        public string ClinicName { get; set; }
        public int InvoiceCount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ReceivableAmount { get; set; }
    }
}
