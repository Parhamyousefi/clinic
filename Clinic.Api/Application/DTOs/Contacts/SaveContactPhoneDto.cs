namespace Clinic.Api.Application.DTOs.Contacts
{
    public class SaveContactPhoneDto
    {
        public int ContactId { get; set; }
        public int PhoneNoTypeId { get; set; }
        public string? Number { get; set; }
        public int EditOrNew { get; set; }
    }
}
