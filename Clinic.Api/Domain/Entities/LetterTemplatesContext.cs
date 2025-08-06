namespace Clinic.Api.Domain.Entities
{
    public class LetterTemplatesContext
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Template { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
