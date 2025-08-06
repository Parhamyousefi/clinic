namespace Clinic.Api.Domain.Entities
{
    public class MedicalNotesContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? Notes { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
