using Clinic.Api.Application.DTOs.Report;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceByClinicResponse>> GetInvoicesByClinic(InvoiceFilterDto filter)
        {
            var result = await (from inv in _context.Invoices
                                join b in _context.Businesses on inv.BusinessId equals b.Id
                                where inv.CreatedOn >= filter.FromDate && inv.CreatedOn <= filter.ToDate
                                group inv by new { b.Id, b.Name } into g
                                select new InvoiceByClinicResponse
                                {
                                    ClinicId = g.Key.Id,
                                    ClinicName = g.Key.Name,
                                    InvoiceCount = g.Count(),
                                    TotalDiscount = g.Sum(x => (decimal?)x.TotalDiscount ?? 0),
                                    ReceivableAmount = g.Sum(x => ((decimal?)x.Amount ?? 0) - ((decimal?)x.TotalDiscount ?? 0))
                                }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<InvoiceByServiceResponse>> GetInvoicesByService(InvoiceFilterDto filter)
        {
            var result = await (from inv in _context.Invoices
                                join ii in _context.InvoiceItems on inv.Id equals ii.InvoiceId
                                join bi in _context.BillableItems on ii.ItemId equals bi.Id
                                where inv.CreatedOn >= filter.FromDate && inv.CreatedOn <= filter.ToDate
                                group new { ii, bi } by new { bi.Id, bi.Name } into g
                                select new InvoiceByServiceResponse
                                {
                                    ServiceId = g.Key.Id,
                                    ServiceName = g.Key.Name,
                                    TotalQuantity = g.Sum(x => (int?)x.ii.Quantity ?? 0),
                                    TotalDiscount = g.Sum(x => (decimal?)x.ii.Discount ?? 0),
                                    ReceivableAmount = g.Sum(x => ((decimal?)x.ii.Amount ?? 0) - ((decimal?)x.ii.Discount ?? 0))
                                }).ToListAsync();

            return result;
        }
    }
}
