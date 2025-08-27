using Clinic.Api.Application.DTOs.Patients;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IPatientService
    {
        Task<string> SavePatient(SavePatientDto model);
        Task<string> DeletePatient(int id);
        Task<IEnumerable<PatientsContext>> GetPatients();
        Task<string> SavePatientPhone(SavePatientPhoneDto model);
        Task<string> DeletePatientPhone(int id);
        Task<IEnumerable<PatientPhonesContext>> GetPatientPhones(int patientId);
    }
}
