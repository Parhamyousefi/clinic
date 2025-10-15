namespace Clinic.Api.Domain.Entities
{
    public class ExpensesContext
    {
        public int Id { get; set; }
        public string? ExpenseNo { get; set; }
        public int BusinessId { get; set; }
        public string? ExpenseDate { get; set; }
        public string? Vendor { get; set; }
        public string? Category { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public string? Notes { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
