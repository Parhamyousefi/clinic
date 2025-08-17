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

        public async Task<int> CreateAppointmentAsync(CreateAppointmentDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                if (model.Start >= model.End)
                    throw new ValidationException(1001, "Start date must be earlier than End date.");

                if (model.PatientId == null)
                    model.PatientId = userId;

                bool hasOverlap = await _context.Appointments
             .AnyAsync(a =>
                 a.PatientId == model.PatientId &&
                 a.BusinessId == model.BusinessId &&
                 (
                     (model.Start >= a.Start && model.Start < a.End) ||
                     (model.End > a.Start && model.End <= a.End) ||
                     (model.Start <= a.Start && model.End >= a.End)
                 ));

                if (hasOverlap)
                    throw new ConflictException(1002, "Patient already has an appointment in this business during this time.");


                var appointment = _mapper.Map<AppointmentsContext>(model);
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

                var selectedDate = date?.Date ?? DateTime.Today;

                return await _context.Appointments
         .Where(u =>
             u.BusinessId == clinicId &&
             u.PractitionerId == userId &&
             u.Start.Date <= selectedDate &&
             u.End.Date >= selectedDate)
         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
