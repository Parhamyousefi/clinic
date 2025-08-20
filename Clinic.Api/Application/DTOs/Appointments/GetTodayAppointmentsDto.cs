namespace Clinic.Api.Application.DTOs.Appointments
{
    public class GetTodayAppointmentsDto
    {
        public DateTime Date { get; set; }
        public int? Arrived { get; set; }
        public int? Clinic { get; set; }
        public int? Service { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
    }
}
