namespace Clinic.Api.Domain.Entities
{
    public class UserBusinessesContext
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int PractitionerId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? User_Id { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatorId { get; set; }
    }
}
