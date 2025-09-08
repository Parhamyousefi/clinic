namespace Clinic.Api.Application.DTOs.Appointments
{
    public class GetTodayAppointmentsInfoDto
    {
        public int Id { get; set; }
        public string Time { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public string AppointmentTypeName { get; set; } = string.Empty;
        public string BillableItemName { get; set; } = string.Empty;
        public string PractitionerName { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
    }
}
