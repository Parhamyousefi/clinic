using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IMainService
    {
        Task<IEnumerable<SectionsContext>> GetSections();
        Task<IEnumerable<BusinessesContext>> GetClinics();
        Task<GlobalResponse> SaveJob(SaveJobDto model);
        Task<IEnumerable<JobsContext>> GetJobs();
        Task<GlobalResponse> DeleteJob(int id);
        Task<IEnumerable<CountriesContext>> GetCountries();
        Task<GlobalResponse> SaveProduct(SaveProductDto model);
        Task<IEnumerable<ProductsContext>> GetProducts();
        Task<GlobalResponse> DeleteProduct(int id);
        Task<GlobalResponse> SaveNote(SaveNoteDto model);
        Task<IEnumerable<GetNotesResponse>> GetNotes(int patientId);
        Task<GlobalResponse> DeleteNote(int noteId);
    }
}
