namespace Clinic.Api.Application.DTOs.Invoices
{
    public class SaveInvoiceDto
    {
        public int BusinessId { get; set; }
        public int PatientId { get; set; }
        public int? AppointmentId { get; set; }
        public string? Notes { get; set; }
        public string? InvoiceNo { get; set; }
        public int EditOrNew { get; set; }
    }
}
