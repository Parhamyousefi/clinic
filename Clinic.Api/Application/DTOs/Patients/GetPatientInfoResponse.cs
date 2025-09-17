namespace Clinic.Api.Application.DTOs.Patients
{
    public class GetPatientInfoResponse
    {
        public string? Mobile { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public string? BirthDate { get; set; }
        public string? FatherName { get; set; }
        public string? NationalCode { get; set; }
        public string? PatientCode { get; set; }
    }
}
