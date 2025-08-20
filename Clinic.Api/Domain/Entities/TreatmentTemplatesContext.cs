namespace Clinic.Api.Domain.Entities
{
    public class TreatmentTemplatesContext
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TemplateNotes { get; set; }
        public string? Title { get; set; }
        public bool ShowPatientBirthDate { get; set; }
        public bool ShowPatientReferenceNumber { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? PrintTemplate { get; set; }
        public int Ordering { get; set; }
        public int? CreatorId { get; set; }
    }
}
