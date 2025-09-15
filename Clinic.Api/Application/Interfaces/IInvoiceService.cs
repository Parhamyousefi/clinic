using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<GlobalResponse> SaveInvoice(SaveInvoiceDto model);
        Task<IEnumerable<InvoicesContext>> GetInvoices();
        Task<GlobalResponse> SaveInvoiceItem(SaveInvoiceItemDto model);
        Task<IEnumerable<InvoiceItemsContext>> GetInvoiceItems();
        Task<GlobalResponse> DeleteInvoice(int id);
        Task<GlobalResponse> DeleteInvoiceItem(int id);
    }
}
