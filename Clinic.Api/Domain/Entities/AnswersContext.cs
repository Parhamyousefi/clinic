namespace Clinic.Api.Domain.Entities
{
    public class AnswersContext
    {
        public int Id { get; set; }
        public string? title { get; set; }
        public string? text { get; set; }
        public string? refTitle { get; set; }
        public int? order { get; set; }
        public bool isDeleted { get; set; }
        public int? Question_Id { get; set; }
    }
}
