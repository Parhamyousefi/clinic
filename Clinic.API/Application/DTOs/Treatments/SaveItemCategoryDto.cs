namespace Clinic.Api.Application.DTOs.Treatments
{
    public class SaveItemCategoryDto
    {
        public string? Name { get; set; }
        public int OrderNo { get; set; }
        public bool DefaultClosed { get; set; }
        public int EditOrNew { get; set; }
    }
}
