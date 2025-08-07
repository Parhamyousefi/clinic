namespace Clinic.Api.Domain.Entities
{
    public class BusinessServicesContext
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int BillableItemId { get; set; }
        public bool IsActive { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
