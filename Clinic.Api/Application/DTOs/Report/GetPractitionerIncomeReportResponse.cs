namespace Clinic.Api.Application.DTOs.Report
{
    public class GetPractitionerIncomeReportResponse
    {
        public string PractitionerName { get; set; }
        public decimal TotalReceipt { get; set; }
    }
}
