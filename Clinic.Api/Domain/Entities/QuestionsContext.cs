namespace Clinic.Api.Domain.Entities
{
    public class QuestionsContext
    {
        public int Id { get; set; }
        public string? title { get; set; }
        public string? type { get; set; }
        public string? normalAnswer { get; set; }
        public string? defaultAnswer { get; set; }
        public string? masterId { get; set; }
        public string? refId { get; set; }
        public int? order { get; set; }
        public bool isDeleted { get; set; }
        public int SectionId { get; set; }
        public bool canCopy { get; set; }
        public bool? canFocusEnd { get; set; }
    }
}
