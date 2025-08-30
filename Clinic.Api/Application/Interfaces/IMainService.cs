using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IMainService
    {
        Task<IEnumerable<SectionsContext>> GetSections();
        Task<string> SaveReceipts(SaveReceiptsDto model);
        Task<IEnumerable<ReceiptsContext>> GetReceipts(int? patientId);
        Task<string> DeleteReceipt(int patientId);
    }
}
