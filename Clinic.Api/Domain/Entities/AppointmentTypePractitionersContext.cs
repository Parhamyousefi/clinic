namespace Clinic.Api.Domain.Entities
{
    public class AppointmentTypePractitionersContext
    {
        public int Id { get; set; }
        public int AppointmentTypeId { get; set; }
        public int PractitionerId { get; set; }
        public bool IsActive { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
