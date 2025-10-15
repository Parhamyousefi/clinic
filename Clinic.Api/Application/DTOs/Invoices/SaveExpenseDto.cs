namespace Clinic.Api.Application.DTOs.Invoices
{
    public class SaveExpenseDto
    {
        public string? ExpenseNo { get; set; }
        public int BusinessId { get; set; }
        public string? ExpenseDate { get; set; }
        public string? Vendor { get; set; }
        public string? Category { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public string? Notes { get; set; }
        public int EditOrNew { get; set; }
    }
}
