namespace Clinic.Api.Domain.Entities
{
    public class PatientMessagesContext
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string? Message { get; set; }
        public string? MobileNo { get; set; }
        public int? PatientId { get; set; }
        public int? UserId { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
