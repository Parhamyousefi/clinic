namespace Clinic.Api.Domain.Entities
{
    public class RecallsContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int RecallTypeId { get; set; }
        public DateTime RecallOn { get; set; }
        public string? Notes { get; set; }
        public bool Recalled { get; set; }
        public DateTime? RecalledAt { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
