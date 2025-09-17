namespace Clinic.Api.Application.DTOs.Appointments
{
    public class SaveBillableItemsDto
    {
        public string? Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsOther { get; set; }
        public int ItemTypeId { get; set; }
        public int Duration { get; set; }
        public bool AllowEditPrice { get; set; }
        public int? TreatmentTemplateId { get; set; }
        public bool ForceOneInvoice { get; set; }
        public bool IsTreatmentDataRequired { get; set; }
        public string? Group { get; set; }
        public int? ParentId { get; set; }
        public int? ItemCategoryId { get; set; }
        public int? OrderInItemCategory { get; set; }
        public bool AutoCopyTreatment { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool NeedAccept { get; set; }
        public string? LastTimeColor { get; set; }
        public int EditOrNew { get; set; }
    }
}
