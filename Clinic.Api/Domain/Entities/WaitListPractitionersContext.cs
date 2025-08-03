namespace Clinic.Api.Domain.Entities
{
    public class WaitListPractitionersContext
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? WaitList_Id { get; set; }
        public int? CreatorId { get; set; }
    }
}
