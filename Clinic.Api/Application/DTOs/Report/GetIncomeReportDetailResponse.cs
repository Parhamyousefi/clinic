namespace Clinic.Api.Application.DTOs.Report
{
    public class GetIncomeReportDetailResponse
    {
        public string PractitionerName { get; set; }
        public string BusinessName { get; set; }
        public decimal TotalReceipt { get; set; }
    }
}
