namespace Clinic.Api.Domain.Entities
{
    public class RecallTypesContext
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int RecallIn { get; set; }
        public int PeriodId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
