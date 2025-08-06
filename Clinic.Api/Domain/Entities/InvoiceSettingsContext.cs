namespace Clinic.Api.Domain.Entities
{
    public class InvoiceSettingsContext
    {
        public int Id { get; set; }
        public int StartingInvoiceNumber { get; set; }
        public string? ExtraBusinessInformation { get; set; }
        public bool ShowBusinessContactInformation { get; set; }
        public bool ShowPatientDOB { get; set; }
        public bool HideLogoAndLetterHead { get; set; }
        public bool ShowNextAppointmentTime { get; set; }
        public string? OfferText { get; set; }
        public string? DefaultNotes { get; set; }
        public string? EmailingInvoiceSubject { get; set; }
        public string? EmailingInvoiceContent { get; set; }
        public string? EmailingOutstandingInvoiceToPatientSubject { get; set; }
        public string? EmailingOutstandingInvoiceToPatientContent { get; set; }
        public string? EmailingPaidInvoice3rdPartySubject { get; set; }
        public string? EmailingPaidInvoice3rdPartyContent { get; set; }
        public string? EmailingOutstandingInvoiceTo3rdPartySubject { get; set; }
        public string? EmailingOutstandingInvoiceTo3rdPartyContent { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
