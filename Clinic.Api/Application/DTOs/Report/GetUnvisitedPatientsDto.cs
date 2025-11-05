namespace Clinic.Api.Application.DTOs.Report
{
    public class GetUnvisitedPatientsDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? UserIds { get; set; }
        public string? BusinessIds { get; set; }
    }
}
