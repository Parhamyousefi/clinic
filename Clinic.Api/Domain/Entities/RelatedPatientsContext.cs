namespace Clinic.Api.Domain.Entities
{
    public class RelatedPatientsContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int RelationId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int RelationPatientId { get; set; }
        public int? CreatorId { get; set; }
    }
}
