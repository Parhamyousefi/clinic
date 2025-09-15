using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IMainService
    {
        Task<IEnumerable<SectionsContext>> GetSections();
        Task<GlobalResponse> SaveReceipt(SaveReceiptDto model);
        Task<IEnumerable<ReceiptsContext>> GetReceipts(int? patientId);
        Task<GlobalResponse> DeleteReceipt(int patientId);
        Task<IEnumerable<BusinessesContext>> GetClinics();
        Task<GlobalResponse> SaveJob(SaveJobDto model);
        Task<IEnumerable<JobsContext>> GetJobs();
        Task<GlobalResponse> DeleteJob(int id);
        Task<IEnumerable<CountriesContext>> GetCountries();
    }
}
