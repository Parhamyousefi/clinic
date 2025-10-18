namespace Clinic.Api.Application.DTOs.Report
{
    public class InvoiceByServiceResponse
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ReceivableAmount { get; set; }
    }
}
