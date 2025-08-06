namespace Clinic.Api.Domain.Entities
{
    public class OnlineBookingsContext
    {
        public int Id { get; set; }
        public bool IsOnlineBookingsActive { get; set; }
        public int MaxAppointmentsPerDaySegment { get; set; }
        public int MinimumAdvanceTimeRequiredForBookings { get; set; }
        public int MinimumNoticeForCancellations { get; set; }
        public bool SMSBookingNotifications { get; set; }
        public bool EmailBookingNotifications { get; set; }
        public string? LogoImage { get; set; }
        public bool ShowPrice { get; set; }
        public bool ShowAppointmentDuration { get; set; }
        public bool RequireAddressOfPatient { get; set; }
        public string? TimeSelectionInfo { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
