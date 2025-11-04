using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Report;

namespace Clinic.Api.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<InvoiceByClinicResponse>> GetInvoicesByClinic(InvoiceFilterDto model);
        Task<IEnumerable<InvoiceByServiceResponse>> GetInvoicesByService(InvoiceFilterDto model);
        Task<GlobalResponse> GetSubmitedAppointments(InvoiceFilterDto model);
        Task<GetSubmitedInvoicesResponse> GetSubmitedInvoices(InvoiceFilterDto model);
        Task<IEnumerable<GetUnpaidInvoicesResponse>> GetUnpaidInvoices(InvoiceFilterDto model);
        Task<IEnumerable<GetPractitionerIncomeReportResponse>> GetPractitionerIncome(IncomeReportFilterDto model);
        Task<IEnumerable<GetBusinessIncomeReportResponse>> GetBusinessIncome(IncomeReportFilterDto model);
        Task<IEnumerable<GetIncomeReportDetailResponse>> GetIncomeReportDetails(IncomeReportFilterDto model);
        Task<GlobalResponse> GetOutPatientSummaryReport(OutPatientReportFilterDto model);
        Task<GlobalResponse> GetOutPatientReportBasedOnCreator(OutPatientReportFilterDto model);
        Task<GetUnvisitedSummaryResponse> GetUnvisitedSummary(GetUnvisitedPatientsDto model);
        Task<GlobalResponse> GetUnvisitedDetails(GetUnvisitedPatientsDto model);
    }
}
