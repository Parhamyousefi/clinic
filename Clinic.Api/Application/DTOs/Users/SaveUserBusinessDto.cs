namespace Clinic.Api.Application.DTOs.Users
{
    public class SaveUserBusinessDto
    {
        public int BusinessId { get; set; }
        public int UserId { get; set; }
        public int EditOrNew { get; set; }
    }
}
