namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveProductDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? SerialNumber { get; set; }
        public string? Supplier { get; set; }
        public decimal Price { get; set; }
        public decimal? StockLevel { get; set; }
        public string? Notes { get; set; }
        public bool IsActive { get; set; }
        public int EditOrNew { get; set; }
    }
}
