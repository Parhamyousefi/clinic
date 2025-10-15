namespace Clinic.Api.Application.DTOs.Questions
{
    public class SaveQuestionValueDto
    {
        public int QuestionId { get; set; }
        public string? selectedValue { get; set; }
        public int InvoiceItemId { get; set; }
        public string? AnswerId { get; set; }
    }
}
