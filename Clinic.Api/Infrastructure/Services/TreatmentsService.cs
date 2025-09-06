using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static Clinic.Api.Middlwares.Exceptions;

namespace Clinic.Api.Infrastructure.Services
{
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReadTokenClaims _token;

        public TreatmentsService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
        {
            _context = context;
            _mapper = mapper;
            _token = token;
        }

        public async Task<int> CreateAppointmentAsync(CreateAppointmentDto model)
        {
            try
            {
                var userRole = _token.GetUserRole();
                if (userRole == "Doctor")
                {
                    model.PractitionerId = _token.GetUserId();
                }
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    if (model.Start >= model.End)
                        throw new ValidationException(1001, "Start date must be earlier than End date.");

                    if (model.PatientId == null)
                        model.PatientId = userId;

                    bool hasOverlap = await _context.Appointments
                 .AnyAsync(a =>
                     a.PatientId == model.PatientId &&
                     a.BusinessId == model.BusinessId &&
                     (
                         (model.Start.Hour >= a.Start.Hour && model.Start.Hour < a.End.Hour) ||
                         (model.End.Hour > a.Start.Hour && model.End.Hour <= a.End.Hour) ||
                         (model.Start.Hour <= a.Start.Hour && model.End.Hour >= a.End.Hour)
                     ));

                    if (hasOverlap)
                        throw new ConflictException(1002, "Patient already has an appointment in this business during this time.");

                    model.ByInvoice = true;
                    var appointment = _mapper.Map<AppointmentsContext>(model);
                    appointment.CreatorId = userId;
                    appointment.CreatedOn = DateTime.UtcNow;
                    _context.Appointments.Add(appointment);
                    await _context.SaveChangesAsync();

                    return appointment.Id;
                }
                else
                {
                    var existingAppointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == model.EditOrNew);

                    if (existingAppointment == null)
                    {
                        throw new Exception("Appointment Not Found");
                    }

                    _mapper.Map(model, existingAppointment);
                    existingAppointment.CreatorId = userId;
                    existingAppointment.LastUpdated = DateTime.UtcNow;
                    _context.Appointments.Update(existingAppointment);
                    await _context.SaveChangesAsync();
                    return existingAppointment.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteAppointment(int id)
        {
            try
            {
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                    throw new Exception("Appointment Not Found");

                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                return "Appointment Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AppointmentsContext>> GetAppointments(int clinicId, DateTime? date, int? docId)
        {
            try
            {
                var userRole = _token.GetUserRole();
                if (userRole == "Doctor")
                {
                    docId = _token.GetUserId();
                }

                var selectedDate = date?.Date ?? DateTime.Today;
                var nextDay = selectedDate.AddDays(1);

                return await _context.Appointments
         .Where(u =>
             u.BusinessId == clinicId &&
             u.PractitionerId == docId &&
             u.Start.Date <= selectedDate &&
             u.End.Date >= selectedDate)
         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TreatmentsContext>> GetTreatments(int appointmentId)
        {
            try
            {
                var result = await _context.Treatments.Where(t => t.AppointmentId == appointmentId).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> SaveTreatment(SaveTreatmentDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var treatment = _mapper.Map<TreatmentsContext>(model);
                    treatment.CreatorId = userId;
                    treatment.CreatedOn = DateTime.UtcNow;
                    _context.Treatments.Add(treatment);
                    await _context.SaveChangesAsync();
                    return "Successfully Saved Treatment";
                }
                else
                {
                    var existingTreatment = await _context.Treatments.FirstOrDefaultAsync(t => t.Id == model.EditOrNew);

                    if (existingTreatment == null)
                    {
                        throw new Exception("Treatment Not Found");
                    }

                    _mapper.Map(model, existingTreatment);
                    existingTreatment.CreatorId = userId;
                    existingTreatment.CreatedOn = DateTime.UtcNow;
                    _context.Treatments.Update(existingTreatment);
                    await _context.SaveChangesAsync();
                    return "Treatment Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteTreatment(int id)
        {
            try
            {
                var treatment = await _context.Treatments.FindAsync(id);
                if (treatment == null)
                    throw new Exception("Treatment Not Found");

                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
                return "Treatment Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AppointmentsContext>> GetTodayAppointments(GetTodayAppointmentsDto model)
        {
            try
            {
                var today = DateTime.Today;
                var query = _context.Appointments.AsQueryable();

                if (!model.FromDate.HasValue && !model.ToDate.HasValue)
                {
                    query = query.Where(a => a.Start.Date <= today && a.End.Date >= today);
                }
                else
                {
                    var fromDate = model.FromDate.Value.Date;
                    var toDate = model.ToDate.Value.Date;

                    query = query.Where(a =>
                         a.Start.Date >= fromDate &&
                          a.End.Date <= toDate
                            );
                }

                if (model.Clinic.HasValue)
                    query = query.Where(a => a.BusinessId == model.Clinic.Value);

                if (model.From.HasValue && model.To.HasValue)
                    query = query.Where(a => a.Start.Hour >= model.From.Value && a.End.Hour <= model.To.Value);

                if (model.Service.HasValue)
                {
                    int serviceId = model.Service.Value;

                    query = query.Where(a =>
                          _context.Treatments.Any(t =>
                             t.AppointmentId == a.Id &&
                              t.TreatmentTemplateId == serviceId
                                    ) &&
                              _context.BillableItems.Any(b =>
                                    b.TreatmentTemplateId == serviceId
                            )
                       );
                }

                    return await query.Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetAppointmentTypesDto>> GetAppointmentTypes()
        {
            try
            {
                var appointmentTypes = await _context.AppointmentTypes.Select(a => new GetAppointmentTypesDto
                {
                    Id = a.Id,
                    Name = a.Name
                }).ToListAsync();

                return appointmentTypes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
