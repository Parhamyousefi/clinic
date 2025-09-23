namespace Clinic.Api.Application.DTOs.Patients
{
    public class SavePatientDto
    {
        public int? TitleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Gender { get; set; }
        public string? FatherName { get; set; }
        public string? BirthDate { get; set; }
        public string? City { get; set; }
        public string? ReferenceNumber { get; set; }
        public int? ReferringDoctorId { get; set; }
        public string? Notes { get; set; }
        public int? ReferringInsurerId { get; set; }
        public int? ReferringInsurer2Id { get; set; }
        public int? ReferringContactId { get; set; }
        public int? ReferringContact2Id { get; set; }
        public string? NationalCode { get; set; }
        public int? JobId { get; set; }
        public int? ReferringInpatientInsurerId { get; set; }
        public int EditOrNew { get; set; }
    }
}
