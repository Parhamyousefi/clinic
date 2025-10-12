namespace Clinic.Api.Application.DTOs.Treatments
{
    public class GetPatientTreatmentsResponse
    {
        public int TreatmentId { get; set; }
        public int? AppointmentId { get; set; }
        public string TemplateTitle { get; set; } = string.Empty;
        public int? BillableItemId { get; set; }
        public List<SectionDto> Sections { get; set; } = new();
        public List<AttachmentDto> Attachments { get; set; } = new();
    }

    public class SectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<QuestionDto> Questions { get; set; } = new();
    }

    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<AnswerDto> Answers { get; set; } = new();
    }

    public class AnswerDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Text { get; set; }
        public string? SelectedValue { get; set; }
    }

    public class AttachmentDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public long FileSize { get; set; }
    }
}
