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

        public async Task<GlobalResponse> CreateAppointmentAsync(CreateAppointmentDto model)
        {
            var result = new GlobalResponse();

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
                    result.Data = appointment.Id;
                    result.Status = 0;
                    return result;
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
                    result.Data = existingAppointment.Id;
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteAppointment(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var appointment = await _context.Appointments.FindAsync(id);
                if (appointment == null)
                    throw new Exception("Appointment Not Found");

                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
                result.Message = "Appointment Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AppointmentsContext>> GetAppointments(GetAppointmentsDto model)
        {
            try
            {
                var userRole = _token.GetUserRole();
                if (userRole == "Doctor")
                {
                    model.DoctorId = _token.GetUserId();
                }

                var selectedDate = model.Date?.Date ?? DateTime.Today;
                var nextDay = selectedDate.AddDays(1);

                return await _context.Appointments
         .Where(u =>
             u.BusinessId == model.ClinicId &&
             u.PractitionerId == model.DoctorId &&
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

        public async Task<GlobalResponse> SaveTreatment(SaveTreatmentDto model)
        {
            var result = new GlobalResponse();

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
                    result.Message = "Treatment Saved Successfully";
                    result.Status = 0;
                    return result;
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
                    result.Message = "Treatment Updated Successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteTreatment(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var treatment = await _context.Treatments.FindAsync(id);
                if (treatment == null)
                    throw new Exception("Treatment Not Found");

                _context.Treatments.Remove(treatment);
                await _context.SaveChangesAsync();
                result.Message = "Treatment Deleted Successfully";
                return result;
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
                         a.Start.Date <= fromDate &&
                          a.End.Date >= toDate
                            );
                }

                if (model.Clinic.HasValue)
                    query = query.Where(a => a.BusinessId == model.Clinic.Value);

                if (model.From.HasValue && model.To.HasValue)
                {
                    var from = model.From.Value;
                    var to = model.To.Value;

                    query = query.Where(a =>
           (a.Start.Hour > from.Hour || (a.Start.Hour == from.Hour && a.Start.Minute >= from.Minute)) &&
           (a.Start.Hour < to.Hour || (a.Start.Hour == to.Hour && a.Start.Minute <= to.Minute))
       );
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

                var result = await (from a in query
                                    join p in _context.Patients on a.PatientId equals p.Id
                                    join u in _context.Users on a.PractitionerId equals u.Id
                                    join at in _context.AppointmentTypes on a.AppointmentTypeId equals at.Id
                                    from t in _context.Treatments.Where(t => t.AppointmentId == a.Id).DefaultIfEmpty()
                                    from b in _context.BillableItems.Where(b => b.TreatmentTemplateId == t.TreatmentTemplateId).DefaultIfEmpty()

                                    select new GetTodayAppointmentsInfoDto
                                    {
                                        Id = a.Id,
                                        Time = a.Start.ToString("HH:mm"),
                                        Date = a.Start.Date,
                                        PatientName = p.FirstName + " " + p.LastName,
                                        AppointmentTypeName = at.Name,
                                        BillableItemName = b != null ? b.Name : string.Empty,
                                        PractitionerName = u.FirstName + " " + u.LastName
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

        public async Task<List<GetTodayAppointmentsInfoDto>> GetWeekAppointments()
        {
            try
            {
                var iranTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time");
                var iranNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, iranTimeZone);
                var today = iranNow.Date;

                var weekEnd = today.AddDays(6);

                var appointments = await (
        from a in _context.Appointments
        where a.Start.Date >= today && a.Start.Date <= weekEnd
        join p in _context.Patients on a.PatientId equals p.Id into patientJoin
        from p in patientJoin.DefaultIfEmpty()
        join at in _context.AppointmentTypes on a.AppointmentTypeId equals at.Id into atJoin
        from at in atJoin.DefaultIfEmpty()
        join u in _context.Users on a.PractitionerId equals u.Id into userJoin
        from u in userJoin.DefaultIfEmpty()
        join t in _context.Treatments on a.Id equals t.AppointmentId into treatmentJoin
        from t in treatmentJoin.DefaultIfEmpty()
        join b in _context.BillableItems on t.TreatmentTemplateId equals b.TreatmentTemplateId into billableJoin
        from b in billableJoin.DefaultIfEmpty()
        select new
        {
            Appointment = a,
            PatientName = (p.FirstName + " " + p.LastName) ?? string.Empty,
            AppointmentTypeName = at.Name ?? string.Empty,
            PractitionerName = (u.FirstName + " " + u.LastName) ?? string.Empty,
            BillableItemName = b.Name ?? string.Empty
        }
    ).ToListAsync();

                var result = new List<GetTodayAppointmentsInfoDto>();

                for (int i = 0; i < 7; i++)
                {
                    var day = today.AddDays(i);

                    if (day.DayOfWeek == DayOfWeek.Friday)
                        continue;

                    int dayNumber = ((int)day.DayOfWeek + 1) % 7;
                    if (dayNumber == 0) dayNumber = 7;

                    var dayAppointments = appointments
           .Where(a => a.Appointment.Start.Date == day.Date)
           .Select(a => new GetTodayAppointmentsInfoDto
           {
               Id = a.Appointment.Id,
               Time = a.Appointment.Start.ToString("HH:mm"),
               PatientName = a.PatientName,
               AppointmentTypeName = a.AppointmentTypeName,
               BillableItemName = a.BillableItemName,
               PractitionerName = a.PractitionerName,
               Date = a.Appointment.Start.Date,
               DayNumber = dayNumber
           })
           .ToList();

                    result.AddRange(dayAppointments);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BillableItemsContext>> GetBillableItems()
        {
            try
            {
                var result = await _context.BillableItems.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> SaveBillableItem(SaveBillableItemsDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var billableItems = _mapper.Map<BillableItemsContext>(model);
                    billableItems.CreatorId = userId;
                    billableItems.CreatedOn = DateTime.UtcNow;
                    _context.BillableItems.Add(billableItems);
                    await _context.SaveChangesAsync();
                    result.Message = "BillableItem Saved Successfully";
                    return result;
                }
                else
                {
                    var existingBillable = await _context.BillableItems.FirstOrDefaultAsync(b => b.Id == model.EditOrNew);

                    if (existingBillable == null)
                    {
                        throw new Exception("BillableItem Not Found");
                    }

                    _mapper.Map(model, existingBillable);
                    existingBillable.ModifierId = userId;
                    existingBillable.LastUpdated = DateTime.UtcNow;
                    _context.BillableItems.Update(existingBillable);
                    await _context.SaveChangesAsync();
                    result.Message = "BillableItem Updated Successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteBillableItem(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var billableItem = await _context.BillableItems.FindAsync(id);

                if (billableItem == null)
                {
                    throw new Exception("BillableItem Not Found");
                }

                _context.BillableItems.Remove(billableItem);
                await _context.SaveChangesAsync();
                result.Message = "BillableItem Deleted Successfully";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<SectionsContext>> GetSectionPerService(int serviceId)
        {
            try
            {
                var res = await _context.Sections.Where(s => s.TreatmentTemplateId == serviceId).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<QuestionsContext>> GetQuestionsPerSection(int sectionId)
        {
            try
            {
                var res = await _context.Questions.Where(q => q.SectionId == sectionId).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AnswersContext>> GetAnswersPerQuestion(int questionId)
        {
            try
            {
                var res = await _context.Answers.Where(a => a.Question_Id == questionId).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetServicesPerPatientResponse>> GetPatientServices(int patientId)
        {
            try
            {
                var result = await (
                    from inv in _context.Invoices
                    join item in _context.InvoiceItems on inv.Id equals item.InvoiceId
                    join bill in _context.BillableItems on item.ItemId equals bill.Id
                    where inv.PatientId == patientId
                    select new GetServicesPerPatientResponse
                    {
                        InvoiceId = inv.Id,
                        InvoiceItemId = item.Id,
                        BillableItemName = bill.Name,
                        BillableItemPrice = bill.Price,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        Amount = item.Amount
                    }
                ).ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
