namespace Clinic.Api.Application.DTOs.UserDto.UserDto
{
    public class RegisterUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? RoleId { get; set; }
    }
}
