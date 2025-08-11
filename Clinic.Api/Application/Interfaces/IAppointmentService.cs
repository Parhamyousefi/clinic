using Clinic.Api.Application.DTOs.Appointments;

namespace Clinic.Api.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<int> CreateAppointmentAsync(CreateAppointmentDto dto);
    }
}
