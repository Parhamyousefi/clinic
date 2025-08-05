namespace Clinic.Api.Domain.Entities
{
    public class PatientPhonesContext
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PhoneNoTypeId { get; set; }
        public string? Number { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
