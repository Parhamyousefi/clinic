using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Report;

namespace Clinic.Api.Application.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<InvoiceByClinicResponse>> GetInvoicesByClinic(InvoiceFilterDto model);
        Task<IEnumerable<InvoiceByServiceResponse>> GetInvoicesByService(InvoiceFilterDto model);
        Task<GlobalResponse> GetAppointmentsAndUnpaidInvoices(InvoiceFilterDto model);
    }
}
