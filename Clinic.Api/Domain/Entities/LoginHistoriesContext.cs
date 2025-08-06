namespace Clinic.Api.Domain.Entities
{
    public class LoginHistoriesContext
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Ip { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string? HostName { get; set; }
    }
}
