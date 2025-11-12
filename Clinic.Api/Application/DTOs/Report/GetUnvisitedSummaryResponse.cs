namespace Clinic.Api.Application.DTOs.Report
{
    public class GetUnvisitedSummaryResponse
    {
        public int TotalCount { get; set; }       
        public int UnArrivedCount { get; set; }     
        public int CancelledCount { get; set; }
    }
}
