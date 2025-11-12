namespace Clinic.Api.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool IsDoctor { get; set; }
        public bool ShowTreatmentOnClick { get; set; }
        public bool CanChangeOldTreatment { get; set; }
        public int SuspendReservationDays { get; set; }
        public int OutOfRangePatients { get; set; }
        public string? DoctorSkill { get; set; }
        public string? Description { get; set; }
        public int? TitleId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool ShowInOnlineBookings { get; set; }
        public bool LoadLastDataOnNewTreatment { get; set; }
        public bool SMSEnabled { get; set; }
        public bool CanConfirmInvoice { get; set; }
        public string? BusinessIds { get; set; }
        public string? AppointmentTypesIds { get; set; }
    }
}
