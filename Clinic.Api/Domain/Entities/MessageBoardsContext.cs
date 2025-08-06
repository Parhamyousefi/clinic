namespace Clinic.Api.Domain.Entities
{
    public class MessageBoardsContext
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
