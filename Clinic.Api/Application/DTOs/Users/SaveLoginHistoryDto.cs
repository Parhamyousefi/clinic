namespace Clinic.Api.Application.DTOs.Users
{
    public class SaveLoginHistoryDto
    {
        public string? UserName { get; set; }
        public string? Ip { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string? HostName { get; set; }
    }
}
