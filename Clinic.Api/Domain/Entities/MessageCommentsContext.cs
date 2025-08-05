namespace Clinic.Api.Domain.Entities
{
    public class MessageCommentsContext
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? MessageBoard_Id { get; set; }
        public int? CreatorId { get; set; }
    }
}
