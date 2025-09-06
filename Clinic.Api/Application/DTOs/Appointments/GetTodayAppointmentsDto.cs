namespace Clinic.Api.Application.DTOs.Appointments
{
    public class GetTodayAppointmentsDto
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Clinic { get; set; }
        public int? Service { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
    }
}
