namespace Clinic.Api.Domain.Entities
{
    public class ProductsContext
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public string? Supplier { get; set; }
        public decimal Price { get; set; }
        public decimal? StockLevel { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
