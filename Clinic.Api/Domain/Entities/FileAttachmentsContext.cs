namespace Clinic.Api.Domain.Entities
{
    public class FileAttachmentsContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? FileName { get; set; }
        public int? FileContent { get; set; }
        public string? Description { get; set; }
        public long FileSize { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
        public int? TreatmentId { get; set; }
    }
}
