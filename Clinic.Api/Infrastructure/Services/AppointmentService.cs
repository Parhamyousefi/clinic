using AutoMapper;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Clinic.Api.Middlwares.Exceptions;

namespace Clinic.Api.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReadTokenClaims _token;

        public AppointmentService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
        {
            _context = context;
            _mapper = mapper;
            _token = token;
        }

        public async Task<int> CreateAppointmentAsync(CreateAppointmentDto dto)
        {
            try
            {
                var userId = _token.GetUserId();

                if (dto.Start >= dto.End)
                    throw new ValidationException(1001, "Start date must be earlier than End date.");

                if (dto.PatientId == null)
                    dto.PatientId = userId;

                bool hasOverlap = await _context.Appointments
             .AnyAsync(a =>
                 a.PatientId == dto.PatientId &&
                 a.BusinessId == dto.BusinessId &&
                 (
                     (dto.Start >= a.Start && dto.Start < a.End) ||
                     (dto.End > a.Start && dto.End <= a.End) ||
                     (dto.Start <= a.Start && dto.End >= a.End)
                 ));

                if (hasOverlap)
                    throw new ConflictException(1002, "Patient already has an appointment in this business during this time.");


                var appointment = _mapper.Map<AppointmentsContext>(dto);
                appointment.CreatorId = userId;
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return appointment.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AppointmentsContext>> GetAppointments(int clinicId, DateTime? date)
        {
            try
            {
                var userId = _token.GetUserId();

                var appointment = await _context.Appointments.Where(u => u.Id == clinicId && u.Start == date)
                                                .ToListAsync();

                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
