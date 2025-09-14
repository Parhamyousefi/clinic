namespace Clinic.Api.Application.DTOs.Appointments
{
    public class GetAppointmentsDto
    {
        public int? ClinicId { get; set; }
        public DateTime? Date { get; set; }
        public int? DoctorId { get; set; }
    }
}
