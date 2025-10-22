namespace Clinic.Api.Application.DTOs.Invoices
{
    public class SaveInvoiceDiscountDto
    {
        public int? InvoiceId { get; set; }
        public decimal TotalDiscount { get; set; }
    }
}
