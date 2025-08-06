namespace Clinic.Api.Domain.Entities
{
    public class ExpenseItemsContext
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal UnitCostPrice { get; set; }
        public decimal Quantity { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int ExpenseId { get; set; }
        public int? CreatorId { get; set; }
    }
}
