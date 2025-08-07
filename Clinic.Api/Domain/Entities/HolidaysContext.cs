namespace Clinic.Api.Domain.Entities
{
    public class HolidaysContext
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
