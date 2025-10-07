namespace Clinic.Api.Application.DTOs.Questions
{
    public class SaveQuestionValueDto
    {
        public int QuestionId { get; set; }
        public string? selectedValue { get; set; }
        public int InvoiceItemId { get; set; }
        public int TreatmentId { get; set; }
        public int? AnswerId { get; set; }
    }
}
