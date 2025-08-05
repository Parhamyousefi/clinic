namespace Clinic.Api.Domain.Entities
{
    public class ProductCardexesContext
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockAdjustmentTypeId { get; set; }
        public decimal Quantity { get; set; }
        public string? Notes { get; set; }
        public string? ObjectType { get; set; }
        public int? ObjectId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
