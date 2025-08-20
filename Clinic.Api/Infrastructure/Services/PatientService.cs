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

                var patient = _mapper.Map<PatientsContext>(model);
                patient.CreatorId = userId;
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return "Patient Saved Successfully";
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

                var patient = _context.PatientPhones.Where(p => p.PatientId == model.PatientId).ToListAsync();

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
                    .SetProperty(x => x.CreatorId, userId));
                await _context.SaveChangesAsync();
                return "Patient Phone Updated Successfully";
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
    }
}
