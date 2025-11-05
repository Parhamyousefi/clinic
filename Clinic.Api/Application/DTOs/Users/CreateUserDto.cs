namespace Clinic.Api.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? IsDoctor { get; set; }
        public int? ShowTreatmentOnClick { get; set; }
        public int? CanChangeOldTreatment { get; set; }
        public int? SuspendReservationDays { get; set; }
        public int? OutOfRangePatients { get; set; }
        public string? DoctorSkill { get; set; }
        public string? Description { get; set; }
        public int? TitleId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
