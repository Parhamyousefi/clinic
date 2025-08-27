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
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostCode { get; set; }
        public int? CountryId { get; set; }
        public int? ReminderTypeId { get; set; }
        public bool UnsubscribeFromSMSMarketing { get; set; }
        public bool ReceiveBookingConfirmationEmails { get; set; }
        public string? InvoiceTo { get; set; }
        public string? EmailInvoiceTo { get; set; }
        public string? InvoiceExtraInformation { get; set; }
        public string? EmergencyContact { get; set; }
        public string? ReferenceNumber { get; set; }
        public int? ReferringDoctorId { get; set; }
        public string? Notes { get; set; }
        public int? ReferringInsurerId { get; set; }
        public int? ReferringInsurer2Id { get; set; }
        public int? ReferringContactId { get; set; }
        public int? ReferringContact2Id { get; set; }
        public int? ReferringPatientId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? PatientCode { get; set; }
        public int? CreatorId { get; set; }
        public string? NationalCode { get; set; }
        public int? JobId { get; set; }
        public int? ReferringInpatientInsurerId { get; set; }
        public decimal? Balance { get; set; }
        public decimal OutBalance { get; set; }
        public decimal InBalance { get; set; }
        public bool Paperless { get; set; }
        public int EditOrNew { get; set; }
    }
}
