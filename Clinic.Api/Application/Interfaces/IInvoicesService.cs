using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IInvoicesService
    {
        Task<string> SaveInvoices(SaveInvoicesDto model);
        Task<IEnumerable<InvoicesContext>> GetInvoices();
        Task<string> SaveInvoiceItems(SaveInvoiceItemsDto model);
        Task<IEnumerable<InvoiceItemsContext>> GetInvoiceItems();
    }
}
