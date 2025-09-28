namespace Clinic.Api.Domain.Entities
{
    public class QuestionValuesContext
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string? selectedValue { get; set; }
        public int TreatmentId { get; set; }
        public int? AnswerId { get; set; }
        public int? CreatorId { get; set; }
    }
}
