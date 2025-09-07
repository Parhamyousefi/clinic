namespace Clinic.Api.Application.DTOs.Main
{
    public class SaveJobDto
    {
        public string? Name { get; set; }
        public int? CreatorId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int EditOrNew { get; set; }
    }
}
