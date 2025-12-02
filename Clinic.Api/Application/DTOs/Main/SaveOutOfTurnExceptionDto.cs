namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveOutOfTurnExceptionDto
    {
        public DateTime GrigoryDate { get; set; }
        public string? StartDate { get; set; }
        public int PractitionerId { get; set; }
        public int BusinessId { get; set; }
        public int OutOfTurn { get; set; }
        public int EditOrNew { get; set; }
    }
}
