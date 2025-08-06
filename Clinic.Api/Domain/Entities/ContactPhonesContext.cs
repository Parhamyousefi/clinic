namespace Clinic.Api.Domain.Entities
{
    public class ContactPhonesContext
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int PhoneNoTypeId { get; set; }
        public string? Number { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? PhoneNoType_Id { get; set; }
        public int? CreatorId { get; set; }
    }
}
