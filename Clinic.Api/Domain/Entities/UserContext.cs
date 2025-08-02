using System.Data;

namespace Clinic.Api.Domain.Entities
{
    public class UserContext
    {
        public int Id { get; set; }
        public int? TitleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool IsPractitioner { get; set; }
        public bool IsActive { get; set; }
        public int? RoleId { get; set; }
        public string? Password { get; set; }
        public string? Designation { get; set; }
        public string? Description { get; set; }
        public int? CancelNotificationTypeId { get; set; }
        public bool ShowInOnlineBookings { get; set; }
        public string? Image { get; set; }
        public bool ShowTreatmentOnClickPatientName { get; set; }
        public string? ForgetKey { get; set; }
        public DateTime? ForgetDateTime { get; set; }
        public int? DefaultTreatmentTemplateId { get; set; }
        public bool LoadLastDataOnNewTreatment { get; set; }
        public int SuspendReservationDays { get; set; }
        public bool SMSEnabled { get; set; }
        public bool CanChangeOldTreatment { get; set; }
        public bool CanConfirmInvoice { get; set; }
        public int OutOfRange { get; set; }
        public RoleContext? Role { get; set; }
    }
}
