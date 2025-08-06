namespace Clinic.Api.Domain.Entities
{
    public class AppointmentServicesContext
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int BillableItemId { get; set; }
        public bool IsActive { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
