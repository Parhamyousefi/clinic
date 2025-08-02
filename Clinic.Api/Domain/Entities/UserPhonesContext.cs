namespace Clinic.Api.Domain.Entities
{
    public class UserPhonesContext
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte PhoneNoTypeId { get; set; }
        public string? Number { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
