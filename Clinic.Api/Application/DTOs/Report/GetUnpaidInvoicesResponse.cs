namespace Clinic.Api.Application.DTOs.Report
{
    public class GetUnpaidInvoicesResponse
    {
        public string InvoiceNo { get; set; }
        public string PatientFullName { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}
