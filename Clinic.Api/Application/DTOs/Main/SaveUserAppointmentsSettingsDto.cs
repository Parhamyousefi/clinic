namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveUserAppointmentsSettingsDto
    {
        public int PractitionerId { get; set; }
        public int BusinessId { get; set; }
        public int? DefaultAppointmentTypeId { get; set; }
        public int? NewPatientAppointmentTypeId { get; set; }
        public int OutOfTurn { get; set; }
        public int TimeSlotSize { get; set; }
        public int CalendarTimeFrom { get; set; }
        public int CalendarTimeTo { get; set; }
        public bool MultipleAppointment { get; set; }
        public int EditOrNew { get; set; }
    }
}
