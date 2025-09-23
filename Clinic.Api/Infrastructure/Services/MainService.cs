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

        public async Task<GlobalResponse> SaveProduct(SaveProductDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var product = _mapper.Map<ProductsContext>(model);
                    product.CreatorId = userId;
                    product.CreatedOn = DateTime.UtcNow;
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();
                    result.Data = "Product Saved Successfully";
                    result.Status = 0;
                    return result;
                }
                else
                {
                    var existingProduct = await _context.Products.FirstOrDefaultAsync(j => j.Id == model.EditOrNew);
                    if (existingProduct == null)
                    {
                        throw new Exception("Product Not Found");
                    }

                    _mapper.Map(model, existingProduct);
                    existingProduct.ModifierId = userId;
                    existingProduct.LastUpdated = DateTime.UtcNow;
                    _context.Products.Update(existingProduct);
                    await _context.SaveChangesAsync();
                    result.Data = "Product Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ProductsContext>> GetProducts()
        {
            try
            {
                var result = await _context.Products.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteProduct(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                    throw new Exception("Product Not Found");

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                result.Data = "Product Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
