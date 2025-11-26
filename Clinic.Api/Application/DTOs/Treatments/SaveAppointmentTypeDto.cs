namespace Clinic.Api.Application.DTOs.Treatments
{
    public class SaveAppointmentTypeDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Duration { get; set; }
        public int MaximumNumberOfPatients { get; set; }
        public int? RelatedBillableItemId { get; set; }
        public int? RelatedBillableItem2Id { get; set; }
        public int? RelatedBillableItem3Id { get; set; }
        public int? DefaultTreatmentNoteTemplate { get; set; }
        public int? RelatedProductId { get; set; }
        public int? RelatedProduct2Id { get; set; }
        public int? RelatedProduct3Id { get; set; }
        public string? Color { get; set; }
        public bool SendBookingConfirmationEmail { get; set; }
        public bool SendReminderEmail { get; set; }
        public bool ShowInOnlineBookings { get; set; }
        public bool IsFirstEncounter { get; set; }
        public int EditOrNew { get; set; }
    }
}
