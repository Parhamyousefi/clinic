using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IMainService
    {
        Task<IEnumerable<SectionsContext>> GetSections();
        Task<string> SaveReceipt(SaveReceiptDto model);
        Task<IEnumerable<ReceiptsContext>> GetReceipts(int? patientId);
        Task<string> DeleteReceipt(int patientId);
        Task<IEnumerable<BusinessesContext>> GetClinics();
        Task<string> SaveJob(SaveJobDto model);
        Task<IEnumerable<JobsContext>> GetJobs();
        Task<string> DeleteJob(int id);
        Task<IEnumerable<BillableItemsContext>> GetBillableItems();
        Task<IEnumerable<CountriesContext>> GetCountries();
    }
}
