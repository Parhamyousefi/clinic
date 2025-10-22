namespace Clinic.Api.Application.DTOs.Treatments
{
    public class GetTodayAppointmentsInfoDto
    {
        public int Id { get; set; }
        public string Time { get; set; } = string.Empty;
        public string PatientName { get; set; } = string.Empty;
        public int? PatientId { get; set; }
        public string AppointmentTypeName { get; set; } = string.Empty;
        public List<string> BillableItemNames { get; set; }
        public string PractitionerName { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
        public int DayNumber { get; set; }
        public int Status { get; set; }
        public string? BillableItemName { get; set; }
    }
}
