namespace Clinic.Api.Application.DTOs
{
    public class SaveAttachmentsDto
    {
        public int PatientId { get; set; }
        public string? FileName { get; set; }
        public string? Base64 { get; set; }
        public int? TreatmentId { get; set; }
        public int EditOrNew { get; set; }
    }
}
