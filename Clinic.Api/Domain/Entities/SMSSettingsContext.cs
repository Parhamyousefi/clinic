namespace Clinic.Api.Domain.Entities
{
    public class SMSSettingsContext
    {
        public int Id { get; set; }
        public bool SendAfterAppointment { get; set; }
        public bool SendBeforeAppointmentDay { get; set; }
        public int SendAfterAppointmentTemplateId { get; set; }
        public int SendBeforeAppointmentDayTemplateId { get; set; }
        public int ReminderDaysBefore { get; set; }
        public string? SendAfterAppointmentTemplate { get; set; }
        public string? SendBeforeAppointmentDayTemplate { get; set; }
    }
}
