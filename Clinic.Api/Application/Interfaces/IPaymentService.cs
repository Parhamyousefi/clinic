using Clinic.Api.Application.DTOs.Payments;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<string> SavePayment(SavePaymentDto model);
        Task<IEnumerable<PaymentsContext>> GetAllPayments();
        Task<IEnumerable<PaymentsContext>> GetPayment(int patientId);
        Task<string> DeletePayment(int id);
    }
}
