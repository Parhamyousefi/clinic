namespace Clinic.Api.Application.DTOs.Report
{
    public class IncomeReportFilterDto
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? FromTime { get; set; }
        public string? ToTime { get; set; }
    }
}
