namespace Clinic.Api.Domain.Entities
{
    public class SectionsContext
    {
        public int Id { get; set; }
        public int TreatmentTemplateId { get; set; }
        public string? title { get; set; }
        public bool defaultClose { get; set; }
        public int? order { get; set; }
        public bool isDeleted { get; set; }
        public bool? horizontalDirection { get; set; }
    }
}
