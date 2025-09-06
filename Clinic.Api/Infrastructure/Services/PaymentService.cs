using AutoMapper;
using Clinic.Api.Application.DTOs.Payments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IReadTokenClaims _token;

        public PaymentService(IMapper mapper, ApplicationDbContext context, IReadTokenClaims token)
        {
            _mapper = mapper;
            _context = context;
            _token = token;
        }

        public async Task<string> SavePayment(SavePaymentDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var payments = _mapper.Map<PaymentsContext>(model);
                    payments.CreatorId = userId;
                    payments.CreatedOn = DateTime.UtcNow;
                    _context.Payments.Add(payments);
                    await _context.SaveChangesAsync();
                    return "Pyament Saved Successfully";
                }
                else
                {
                    var existingPayments = await _context.Payments.FirstOrDefaultAsync(i => i.Id == model.EditOrNew);

                    if (existingPayments == null)
                    {
                        throw new Exception("Payment Not Found");
                    }

                 
                    _mapper.Map(model, existingPayments);
                    existingPayments.ModifierId = userId;
                    existingPayments.LastUpdated = DateTime.UtcNow;
                    _context.Payments.Update(existingPayments);
                    await _context.SaveChangesAsync();
                    return "Pyament Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PaymentsContext>> GetAllPayments()
        {
            try
            {
                var result = await _context.Payments.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<PaymentsContext>> GetPayment(int patientId)
        {
            try
            {
                var payment = await _context.Payments.Where(p => p.PatientId == patientId).ToListAsync();
                return payment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeletePayment(int id)
        {
            try
            {
                var result = await _context.Payments.FindAsync(id);
                if (result == null)
                    throw new Exception("Payment Not Found");

                _context.Payments.Remove(result);
                await _context.SaveChangesAsync();
                return "Payment Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
