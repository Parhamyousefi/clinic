using AutoMapper;
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

        public async Task<string> SaveReceipts(SaveReceiptsDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                var receipt = await _context.Receipts.FirstOrDefaultAsync(r => r.PatientId == model.PatientId);

                if (receipt == null)
                {
                    var mappReceipt = _mapper.Map<ReceiptsContext>(model);
                    mappReceipt.CreatorId = userId;
                    _context.Receipts.Add(mappReceipt);
                    await _context.SaveChangesAsync();

                    return "Receipt Saved Successfully";
                }

                _mapper.Map(model, receipt);
                _context.Receipts.Update(receipt);
                await _context.SaveChangesAsync();
                return "Receipt Updated Successfully";
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

        public async Task<string> DeleteReceipt(int patientId)
        {
            try
            {
                var receipt = await _context.Receipts.FirstOrDefaultAsync(r => r.PatientId == patientId);
                if (receipt == null)
                    throw new Exception("Receipt Not Found");

                _context.Receipts.Remove(receipt);
                await _context.SaveChangesAsync();
                return "Receipt Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
