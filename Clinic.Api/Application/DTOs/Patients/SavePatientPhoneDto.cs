namespace Clinic.Api.Application.DTOs.Patients
{
    public class SavePatientPhoneDto
    {
        public int PatientId { get; set; }
        public int PhoneNoTypeId { get; set; }
        public string? Number { get; set; }
        public int EditOrNew { get; set; }
    }
}
