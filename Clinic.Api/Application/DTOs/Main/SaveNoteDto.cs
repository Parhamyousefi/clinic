namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveNoteDto
    {
        public string? Note { get; set; }
        public int PatientId { get; set; }
        public int EditOrNew { get; set; }
    }
}
