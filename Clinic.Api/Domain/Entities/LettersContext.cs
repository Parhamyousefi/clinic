namespace Clinic.Api.Domain.Entities
{
    public class LettersContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? Content { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LetterNo { get; set; }
        public string? Subject { get; set; }
        public int? CreatorId { get; set; }
    }
}
