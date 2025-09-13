using AutoMapper;
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

        public async Task<string> SavePatient(SavePatientDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {   
                    var patient = _mapper.Map<PatientsContext>(model);
                    patient.CreatorId = userId;
                    patient.CreatedOn = DateTime.UtcNow;
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();

                    return "Patient Saved Successfully";
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
                    existingPatient.LastUpdated = DateTime.UtcNow;
                    _context.Patients.Update(existingPatient);
                    await _context.SaveChangesAsync();
                    return "Patient Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeletePatient(int id)
        {
            try
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                    throw new Exception("Patient Not Found");

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
                return "Patient Deleted Successfully";
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

        public async Task<string> SavePatientPhone(SavePatientPhoneDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                var patient = await _context.PatientPhones.Where(p => p.PatientId == model.PatientId).ToListAsync();

                if (patient == null)
                {
                    var mappPatient = _mapper.Map<PatientPhonesContext>(model);
                    mappPatient.CreatorId = userId;
                    _context.PatientPhones.Add(mappPatient);
                    await _context.SaveChangesAsync();

                    return "Patient Phone Saved Successfully";
                }

                await _context.PatientPhones.Where(p => p.PatientId == model.PatientId)
                    .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.PhoneNoTypeId, model.PhoneNoTypeId)
                    .SetProperty(x => x.Number, model.Number)
                    .SetProperty(x => x.ModifierId, model.ModifierId)
                    .SetProperty(x => x.CreatedOn, model.CreatedOn)
                    .SetProperty(x => x.LastUpdated, model.LastUpdated)
                    .SetProperty(x => x.ModifierId, userId));
                await _context.SaveChangesAsync();
                return "Patient Phone Updated Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeletePatientPhone(int id)
        {
            try
            {
                var patientPhone = await _context.PatientPhones.FindAsync(id);
                if (patientPhone == null)
                    throw new Exception("Patient Phone Not Found");

                _context.PatientPhones.Remove(patientPhone);
                await _context.SaveChangesAsync();
                return "Patient Phone Deleted Successfully";
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

        public async Task<IEnumerable<ContactTypesContext>> GetContactTypes()
        {
            try
            {
                var patientPhone = await _context.ContactTypes.ToListAsync();
                return patientPhone;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
