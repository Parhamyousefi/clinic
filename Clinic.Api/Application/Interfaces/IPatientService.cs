using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Patients;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IPatientService
    {
        Task<GlobalResponse> SavePatient(SavePatientDto model);
        Task<GlobalResponse> DeletePatient(int id);
        Task<IEnumerable<PatientsContext>> GetPatients();
        Task<IEnumerable<GetPatientInfoResponse>> GetPatientById(int patientId);
        Task<GlobalResponse> SavePatientPhone(SavePatientPhoneDto model);
        Task<GlobalResponse> DeletePatientPhone(int id);
        Task<IEnumerable<PatientPhonesContext>> GetPatientPhones(int patientId);
        Task<IEnumerable<AppointmentsContext>> GetPatientAppointments(int patientId);
    }
}
