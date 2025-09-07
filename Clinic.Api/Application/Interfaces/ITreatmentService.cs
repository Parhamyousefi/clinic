using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface ITreatmentService
    {
        Task<int> CreateAppointmentAsync(CreateAppointmentDto model);
        Task<string> DeleteAppointment(int id);
        Task<IEnumerable<AppointmentsContext>> GetAppointments(int clinicId, DateTime? date, int? docId);
        Task<IEnumerable<TreatmentsContext>> GetTreatments(int appointmentId);
        Task<string> SaveTreatment(SaveTreatmentDto model);
        Task<string> DeleteTreatment(int id);
        Task<IEnumerable<GetTodayAppointmentsInfoDto>> GetTodayAppointments(GetTodayAppointmentsDto model);
        Task<IEnumerable<GetAppointmentTypesDto>> GetAppointmentTypes();
    }
}
