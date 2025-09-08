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
    public class TreatmentService : ITreatmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReadTokenClaims _token;

        public TreatmentService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
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
                      a.Start.Date == model.Start.Date &&
        (
            (model.Start.TimeOfDay >= a.Start.TimeOfDay && model.Start.TimeOfDay < a.End.TimeOfDay) ||
            (model.End.TimeOfDay > a.Start.TimeOfDay && model.End.TimeOfDay <= a.End.TimeOfDay) ||
            (model.Start.TimeOfDay <= a.Start.TimeOfDay && model.End.TimeOfDay >= a.End.TimeOfDay)
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
                    existingAppointment.ModifierId = userId;
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
                    existingTreatment.ModifierId = userId;
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

        public async Task<IEnumerable<GetTodayAppointmentsInfoDto>> GetTodayAppointments(GetTodayAppointmentsDto model)
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
                {
                    var from = new TimeSpan(model.From.Value.Hour, model.From.Value.Minute, 0);
                    var to = new TimeSpan(model.To.Value.Hour, model.To.Value.Minute, 0);

                    query = query.Where(a =>
                        new TimeSpan(a.Start.Hour, a.Start.Minute, 0) >= from &&
                        new TimeSpan(a.Start.Hour, a.Start.Minute, 0) <= to);
                }

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

                var result = await query
           .Select(a => new GetTodayAppointmentsInfoDto
           {
               Id = a.Id,
               Time = a.Start.ToString("HH:mm"),
               Date = a.Start.Date,
               PatientName = _context.Patients
                               .Where(p => p.Id == a.PatientId)
                               .Select(p => p.FirstName + " " + p.LastName)
                               .FirstOrDefault() ?? string.Empty,
               AppointmentTypeName = _context.AppointmentTypes
                                       .Where(at => at.Id == a.AppointmentTypeId)
                                       .Select(at => at.Name)
                                       .FirstOrDefault() ?? string.Empty,
               BillableItemName = _context.Treatments
                                   .Where(t => t.AppointmentId == a.Id)
                                   .Join(_context.BillableItems,
                                       t => t.TreatmentTemplateId,
                                       b => b.TreatmentTemplateId,
                                       (t, b) => b.Name)
                                   .FirstOrDefault() ?? string.Empty,
               PractitionerName = _context.Users
                                   .Where(u => u.Id == a.PractitionerId)
                                   .Select(u => u.FirstName + " " + u.LastName)
                                   .FirstOrDefault() ?? string.Empty
           })
           .ToListAsync();

                return result;
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

        public async Task<Dictionary<string, List<GetTodayAppointmentsInfoDto>>> GetWeekAppointments()
        {
            try
            {
                var today = DateTime.Today;
                var weekEnd = today.AddDays(6);

                var query = _context.Appointments.AsQueryable();

                var appointments = await _context.Appointments
       .Where(a => a.Start.Date <= today && a.End.Date >= weekEnd)
       .ToListAsync();

                var result = new Dictionary<string, List<GetTodayAppointmentsInfoDto>>();

                for (int i = 0; i < 7; i++)
                {
                    var day = today.AddDays(i);

                    if (day.DayOfWeek == DayOfWeek.Friday)
                        continue; 

                    string dayName = day.ToString("dddd"); 

                    var dayAppointments = appointments
                        .Where(a => a.Start.Date == day.Date)
                        .Select(a => new GetTodayAppointmentsInfoDto
                        {
                            Id = a.Id,
                            Time = a.Start.ToString("HH:mm"),
                            PatientName = _context.Patients
                               .Where(p => p.Id == a.PatientId)
                               .Select(p => p.FirstName + " " + p.LastName)
                               .FirstOrDefault() ?? string.Empty,
                            AppointmentTypeName = _context.AppointmentTypes
                                       .Where(at => at.Id == a.AppointmentTypeId)
                                       .Select(at => at.Name)
                                       .FirstOrDefault() ?? string.Empty,
                            BillableItemName = _context.Treatments
                                   .Where(t => t.AppointmentId == a.Id)
                                   .Join(_context.BillableItems,
                                       t => t.TreatmentTemplateId,
                                       b => b.TreatmentTemplateId,
                                       (t, b) => b.Name)
                                   .FirstOrDefault() ?? string.Empty,
                            PractitionerName = _context.Users
                                   .Where(u => u.Id == a.PractitionerId)
                                   .Select(u => u.FirstName + " " + u.LastName)
                                   .FirstOrDefault() ?? string.Empty,
                            Date = a.Start.Date
                        })
                        .ToList();

                    result[dayName] = dayAppointments;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
