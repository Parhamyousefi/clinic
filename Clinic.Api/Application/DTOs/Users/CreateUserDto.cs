namespace Clinic.Api.Application.DTOs.Users
{
    public class CreateUserDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
