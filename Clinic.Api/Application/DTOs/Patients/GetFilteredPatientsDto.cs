namespace Clinic.Api.Application.DTOs.Patients
{
    public class GetFilteredPatientsDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PatientCode { get; set; }
    }
}
