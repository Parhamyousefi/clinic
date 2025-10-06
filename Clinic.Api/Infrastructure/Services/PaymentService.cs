using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IReadTokenClaims _token;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PaymentService(IReadTokenClaims token, ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
        }

        public async Task<GlobalResponse> SavePayment(SavePaymentDto model)
        {
            var result = new GlobalResponse();

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
                    result.Message = "Payment Saved Successfully";
                    result.Status = 0;
                    return result;
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
                    result.Message = "Payment Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetAllPaymentsResponse>> GetAllPayments()
        {
            try
            {
                var query = _context.Payments.AsQueryable();
                var result = await (from a in query
                                    join p in _context.Patients on a.PatientId equals p.Id

                                    select new GetAllPaymentsResponse
                                    {
                                        Id = a.Id,
                                        PaymentNo = a.PaymentNo,
                                        PatientId = a.PatientId,
                                        Cash = a.Cash,
                                        EFTPos = a.EFTPos,
                                        Other = a.Other,
                                        Notes = a.Notes,
                                        ModifierId = a.ModifierId,
                                        CreatedOn = a.CreatedOn,
                                        LastUpdated = a.LastUpdated,
                                        AllowEdit = a.AllowEdit,
                                        CreatorId = a.CreatorId,
                                        PaymentTypeId = a.PaymentTypeId,
                                        PatientName = p.FirstName + " " + p.LastName
                                    })
                                   .ToListAsync();
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

        public async Task<GlobalResponse> DeletePayment(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var payment = await _context.Payments.FindAsync(id);
                if (payment == null)
                    throw new Exception("Payment Not Found");

                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
                result.Message = "Payment Deleted Successfully";
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
