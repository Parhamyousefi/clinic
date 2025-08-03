namespace Clinic.Api.Domain.Entities
{
    public class StockAdjustmentTypesContext
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsOutput { get; set; }
        public bool UseOnAdjust { get; set; }
    }
}
