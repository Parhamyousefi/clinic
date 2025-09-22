using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Patients;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IReadTokenClaims _token;
        private readonly IMapper _mapper;

        public PatientService(ApplicationDbContext context, IReadTokenClaims token, IMapper mapper)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
        }

        public async Task<GlobalResponse> SavePatient(SavePatientDto model)
        {
            var result = new GlobalResponse();
            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var patient = _mapper.Map<PatientsContext>(model);
                    patient.CreatorId = userId;
                    patient.ReferringDoctorId = userId;
                    patient.CreatedOn = DateTime.UtcNow;
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                    result.Data = "Patient Saved Successfully";
                    result.Status = 0;
                    return result;
                }
                else
                {
                    var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == model.EditOrNew);

                    if (existingPatient == null)
                    {
                        throw new Exception("Patient Not Found");
                    }

                    _mapper.Map(model, existingPatient);
                    existingPatient.ModifierId = userId;
                    existingPatient.ReferringDoctorId = userId;
                    existingPatient.LastUpdated = DateTime.UtcNow;
                    _context.Patients.Update(existingPatient);
                    await _context.SaveChangesAsync();
                    result.Data = "Patient Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeletePatient(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                    throw new Exception("Patient Not Found");

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                result.Data = "Patient Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PatientsContext>> GetPatients()
        {
            try
            {
                var userId = _token.GetUserId();

                var patients = await _context.Patients.Where(p => p.ReferringDoctorId == userId).ToListAsync();

                return patients;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetPatientInfoResponse>> GetPatientById(int patientId)
        {
            try
            {
                var query = _context.Patients.AsQueryable();
                var result = await query
                    .Where(p => p.Id == patientId)
                    .Select(a => new GetPatientInfoResponse
                    {
                        Mobile = _context.PatientPhones
                            .Where(p => p.PatientId == patientId)
                            .Select(p => p.Number)
                            .FirstOrDefault() ?? string.Empty,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Gender = a.Gender,
                        BirthDate = a.BirthDate,
                        FatherName = a.FatherName,
                        NationalCode = a.NationalCode,
                        PatientCode = a.PatientCode.ToString()
                    }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> SavePatientPhone(SavePatientPhoneDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();
                if (model.EditOrNew == -1)
                {
                    var patient = await _context.PatientPhones.FindAsync(model.PatientId);

                    if (patient == null)
                    {
                        var mappPatient = _mapper.Map<PatientPhonesContext>(model);
                        mappPatient.CreatorId = userId;
                        _context.PatientPhones.Add(mappPatient);
                        await _context.SaveChangesAsync();
                        result.Data = "Patient Phone Saved Successfully";
                        result.Status = 0;
                        return result;
                    }
                    else
                    {
                        throw new Exception("Patient Phone Already Exists");
                    }
                }
                else
                {
                    var existingPatientPhone = await _context.PatientPhones.FirstOrDefaultAsync(p => p.Id == model.EditOrNew);

                    if (existingPatientPhone == null)
                    {
                        throw new Exception("Patient Not Found");
                    }

                    _mapper.Map(model, existingPatientPhone);
                    existingPatientPhone.ModifierId = userId;
                    existingPatientPhone.LastUpdated = DateTime.UtcNow;
                    _context.PatientPhones.Update(existingPatientPhone);
                    await _context.SaveChangesAsync();
                    result.Data = "Patient Phone Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeletePatientPhone(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var patientPhone = await _context.PatientPhones.FindAsync(id);
                if (patientPhone == null)
                    throw new Exception("Patient Phone Not Found");

                _context.PatientPhones.Remove(patientPhone);
                await _context.SaveChangesAsync();
                result.Data = "Patient Phone Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PatientPhonesContext>> GetPatientPhones(int patientId)
        {
            try
            {
                var patientPhone = await _context.PatientPhones.Where(p => p.PatientId == patientId).ToListAsync();
                return patientPhone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<AppointmentsContext>> GetPatientAppointments(int patientId)
        {
            try
            {
                var result = await _context.Appointments.Where(p => p.PatientId == patientId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<InvoicesContext>> GetPatientInvoices(int patientId)
        {
            try
            {
                var result = await _context.Invoices.Where(i => i.PatientId == patientId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReceiptsContext>> GetPatientReceipts(int patientId)
        {
            try
            {
                var result = await _context.Receipts.Where(r => r.PatientId == patientId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PaymentsContext>> GetPatientPayments(int patientId)
        {
            try
            {
                var result = await _context.Payments.Where(p => p.PatientId == patientId).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
