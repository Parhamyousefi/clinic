using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<GlobalResponse> SavePayment(SavePaymentDto model);
        Task<IEnumerable<GetAllPaymentsResponse>> GetAllPayments();
        Task<IEnumerable<PaymentsContext>> GetPayment(int patientId);
        Task<GlobalResponse> DeletePayment(int id);
    }
}
