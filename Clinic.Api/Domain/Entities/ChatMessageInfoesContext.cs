namespace Clinic.Api.Domain.Entities
{
    public class ChatMessageInfoesContext
    {
        public int Id { get; set; }
        public string? ClientGuid { get; set; }
        public int? ConversationId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Message { get; set; }
        public int? RoomId { get; set; }
        public long Timestamp { get; set; }
        public int UserFromId { get; set; }
        public int? UserToId { get; set; }
    }
}
