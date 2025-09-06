using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IInvoicesService
    {
        Task<string> SaveInvoice(SaveInvoiceDto model);
        Task<IEnumerable<InvoicesContext>> GetInvoices();
        Task<string> SaveInvoiceItem(SaveInvoiceItemDto model);
        Task<IEnumerable<InvoiceItemsContext>> GetInvoiceItems();
        Task<string> DeleteInvoice(int id);
        Task<string> DeleteInvoiceItem(int id);
    }
}
