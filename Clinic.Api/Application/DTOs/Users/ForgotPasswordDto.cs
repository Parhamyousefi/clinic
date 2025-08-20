namespace Clinic.Api.Application.DTOs.Users
{
    public class ForgotPasswordDto
    {
        public string Username { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
    }
}
