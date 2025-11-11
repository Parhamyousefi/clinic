namespace Clinic.Api.Application.DTOs.Report
{
    public class OutPatientReportFilterDto
    {
        public DateTime FromDate { get; set; }
        public string? FromTime { get; set; }
        public DateTime ToDate { get; set; }
        public string? ToTime { get; set; }
        public string? UserId { get; set; }
        public string? ServiceId { get; set; }
        public string? Product { get; set; }
        public string? CreatorId { get; set; }
        public string? IsPaid { get; set; }
        public string? Referral { get; set; }
    }
}
