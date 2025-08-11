using AutoMapper;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;

namespace Clinic.Api.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            var appointment = _mapper.Map<AppointmentsContext>(dto);

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return appointment.Id;
        }
    }
}
