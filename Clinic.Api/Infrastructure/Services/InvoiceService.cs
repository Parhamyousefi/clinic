using AutoMapper;
using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IReadTokenClaims _token;

        public InvoiceService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
        {
            _context = context;
            _mapper = mapper;
            _token = token;
        }

        public async Task<GlobalResponse> SaveInvoice(SaveInvoiceDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var invoice = _mapper.Map<InvoicesContext>(model);
                    invoice.CreatorId = userId;
                    invoice.CreatedOn = DateTime.UtcNow;
                    _context.Invoices.Add(invoice);
                    await _context.SaveChangesAsync();
                    result.Data = "Invoice Saved Successfully";
                    return result;
                }
                else
                {
                    var existingInvoice = await _context.Invoices.FirstOrDefaultAsync(i => i.Id == model.EditOrNew);

                    if (existingInvoice == null)
                    {
                        throw new Exception("Invoice Not Found");
                    }

                    _mapper.Map(model, existingInvoice);
                    existingInvoice.ModifierId = userId;
                    existingInvoice.LastUpdated = DateTime.UtcNow;
                    _context.Invoices.Update(existingInvoice);
                    await _context.SaveChangesAsync();
                    result.Data = "Invoice Updated Successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<InvoicesContext>> GetInvoices()
        {
            try
            {
                var invoices = await _context.Invoices.ToListAsync();
                return invoices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> SaveInvoiceItem(SaveInvoiceItemDto model)
        {
            var result = new GlobalResponse();

            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var invoiceItem = _mapper.Map<InvoiceItemsContext>(model);
                    invoiceItem.CreatorId = userId;
                    invoiceItem.CreatedOn = DateTime.UtcNow;
                    _context.InvoiceItems.Add(invoiceItem);
                    await _context.SaveChangesAsync();
                    result.Data = "Invoice Item Saved Successfully";
                    return result;
                }
                else
                {
                    var existingInvoiceItem = await _context.InvoiceItems.FirstOrDefaultAsync(i => i.Id == model.EditOrNew);

                    if (existingInvoiceItem == null)
                    {
                        throw new Exception("Invoice Item Not Found");
                    }

                    _mapper.Map(model, existingInvoiceItem);
                    existingInvoiceItem.ModifierId = userId;
                    existingInvoiceItem.LastUpdated = DateTime.UtcNow;
                    _context.InvoiceItems.Update(existingInvoiceItem);
                    await _context.SaveChangesAsync();
                    result.Data = "Invoice Item Updated Successfully";
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<InvoiceItemsContext>> GetInvoiceItems()
        {
            try
            {
                var invoiceItems = await _context.InvoiceItems.ToListAsync();
                return invoiceItems;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteInvoice(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var invoice = await _context.Invoices.FindAsync(id);

                if (invoice == null)
                    throw new Exception("Invoice Not Found");

                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
                result.Data = "Invoice Deleted Successfully";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteInvoiceItem(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var invoiceItems = await _context.InvoiceItems.FindAsync(id);
                if (invoiceItems == null)
                    throw new Exception("Invoice Items Not Found");

                _context.InvoiceItems.Remove(invoiceItems);
                await _context.SaveChangesAsync();
                result.Data = "Invoice Item Deleted Successfully";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
