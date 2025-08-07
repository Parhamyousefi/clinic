namespace Clinic.Api.Domain.Entities
{
    public class AppointmentRemindersContext
    {
        public int Id { get; set; }
        public int DefaultReminderTypeId { get; set; }
        public int ReminderPeriod { get; set; }
        public bool SkipWeekends { get; set; }
        public string? ReminderTime { get; set; }
        public string? AppointmentConfirmationSubject { get; set; }
        public string? AppointmentConfirmationContent { get; set; }
        public bool AppointmentConfirmationHideAddress { get; set; }
        public bool EmailReminderEnabled { get; set; }
        public string? EmailReminderSubject { get; set; }
        public string? EmailReminderContent { get; set; }
        public bool SMSReminderEnabled { get; set; }
        public string? SMSReminderText { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
