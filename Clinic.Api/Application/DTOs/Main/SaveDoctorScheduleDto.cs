namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveDoctorScheduleDto
    {
        public int BusinessId { get; set; }
        public int PractitionerId { get; set; } 
        public int Day { get; set; }
        public TimeSpan FromTime { get; set; }
        public TimeSpan ToTime { get; set; }
        public bool IsBreak { get; set; }
        public bool IsActive { get; set; } = true;
        public int? Duration { get; set; }
        public int EditOrNew { get; set; }
    }
}
