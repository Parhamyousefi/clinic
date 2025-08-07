namespace Clinic.Api.Domain.Entities
{
    public class CommunicationsContext
    {
        public int Id { get; set; }
        public int CommunicationTypeId { get; set; }
        public int CommunicationCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int CommunicationDirectionId { get; set; }
        public int PractitionerId { get; set; }
        public string? Message { get; set; }
        public int PatientId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
