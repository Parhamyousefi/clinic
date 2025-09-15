using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class MainService : IMainService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReadTokenClaims _token;

        public MainService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
        {
            _context = context;
            _mapper = mapper;
            _token = token;
        }

        public async Task<IEnumerable<SectionsContext>> GetSections()
        {
            try
            {
                var result = await _context.Sections.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> SaveReceipt(SaveReceiptDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                var receipt = await _context.Receipts.FirstOrDefaultAsync(r => r.PatientId == model.PatientId);

                if (receipt == null)
                {
                    var mappReceipt = _mapper.Map<ReceiptsContext>(model);
                    mappReceipt.CreatorId = userId;
                    mappReceipt.CreatedOn = DateTime.UtcNow;
                    _context.Receipts.Add(mappReceipt);
                    await _context.SaveChangesAsync();
                    result.Data = "Receipt Saved Successfully";
                    result.Status = 0;
                    return result;
                }

                _mapper.Map(model, receipt);
                receipt.ModifierId = userId;
                receipt.LastUpdated = DateTime.UtcNow;
                _context.Receipts.Update(receipt);
                await _context.SaveChangesAsync();
                result.Data = "Receipt Updated Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReceiptsContext>> GetReceipts(int? patientId)
        {
            try
            {
                if (patientId == null)
                {
                    var receipts = await _context.Receipts.ToListAsync();
                    return receipts;
                }

                var receipt = await _context.Receipts.Where(r => r.PatientId == patientId).ToListAsync();
                return receipt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteReceipt(int patientId)
        {
            var result = new GlobalResponse();

            try
            {
                var receipt = await _context.Receipts.FirstOrDefaultAsync(r => r.PatientId == patientId);
                if (receipt == null)
                    throw new Exception("Receipt Not Found");

                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
                result.Data = "Receipt Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<BusinessesContext>> GetClinics()
        {
            try
            {
                var result = await _context.Businesses.Select(b => new BusinessesContext
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> SaveJob(SaveJobDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var job = _mapper.Map<JobsContext>(model);
                    job.CreatorId = userId;
                    job.CreatedOn = DateTime.UtcNow;
                    _context.Jobs.Add(job);
                    await _context.SaveChangesAsync();
                    result.Data = "Job Saved Successfully";
                    result.Status = 0;
                    return result;
                }
                else
                {
                    var existingJob = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == model.EditOrNew);
                    if (existingJob == null)
                    {
                        throw new Exception("Job Not Found");
                    }

                    _mapper.Map(model, existingJob);
                    existingJob.ModifierId = userId;
                    existingJob.LastUpdated = DateTime.UtcNow;
                    _context.Jobs.Update(existingJob);
                    await _context.SaveChangesAsync();
                    result.Data = "Job Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<JobsContext>> GetJobs()
        {
            try
            {
                var jobs = await _context.Jobs.ToListAsync();
                return jobs;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteJob(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var job = await _context.Jobs.FindAsync(id);

                if (job == null)
                    throw new Exception("Job Not Found");

                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                result.Data = "Job Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<IEnumerable<CountriesContext>> GetCountries()
        {
            try
            {
                var result = await _context.Countries.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
