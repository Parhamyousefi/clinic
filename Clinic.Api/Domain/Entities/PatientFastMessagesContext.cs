namespace Clinic.Api.Domain.Entities
{
    public class PatientFastMessagesContext
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string? MobileNo { get; set; }
        public string? Params { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsSuccessful { get; set; }
        public string? ProviderMessage { get; set; }
        public int? PatientId { get; set; }
        public int? CreatorId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
