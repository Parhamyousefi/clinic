namespace Clinic.Api.Application.DTOs.Treatments
{
    public class GetTodayAppointmentsDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Clinic { get; set; }
        public int? Service { get; set; }
        public TimeOnly? From { get; set; }
        public TimeOnly? To { get; set; }
    }
}
