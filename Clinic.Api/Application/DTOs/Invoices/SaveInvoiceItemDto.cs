namespace Clinic.Api.Application.DTOs.Invoices
{
    public class SaveInvoiceItemDto
    {
        public int InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public int? ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public int DiscountTypeId { get; set; }
        public decimal Amount { get; set; }
        public bool IsLock { get; set; }
        public bool Done { get; set; }
        public int EditOrNew { get; set; }
    }
}
