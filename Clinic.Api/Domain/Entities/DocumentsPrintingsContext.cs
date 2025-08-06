namespace Clinic.Api.Domain.Entities
{
    public class DocumentsPrintingsContext
    {
        public int Id { get; set; }
        public byte[]? Logo { get; set; }
        public string? LogoFileName { get; set; }
        public int LogoHeight { get; set; }
        public bool DisplayLogoOnInvoice { get; set; }
        public string? InvoicePageSize { get; set; }
        public int TopMargin { get; set; }
        public string? AccountStatments { get; set; }
        public bool ShowLogoOnLetters { get; set; }
        public int SpaceUnderneathLogoOnLetters { get; set; }
        public int TopMarginOnLetters { get; set; }
        public int BottomMarginLetters { get; set; }
        public int LeftMarginLetters { get; set; }
        public int RightMarginLetters { get; set; }
        public bool DisplayLogoOnTreatment { get; set; }
        public bool HideUnSelectedCheckBoxesOnTreadtment { get; set; }
        public string? TreatmentPageSize { get; set; }
        public string? TopMarginOnTreatment { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
