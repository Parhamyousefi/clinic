using Clinic.Api.Application.DTOs;
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

        public async Task<GlobalResponse> GetAppointmentsAndUnpaidInvoices(InvoiceFilterDto model)
        {
            var response = new GlobalResponse();

            try
            {
                var appointmentCount = await _context.Appointments
                    .CountAsync(a => a.Start >= model.FromDate && a.End <= model.ToDate && (a.Cancelled == false || a.Cancelled == null));

                var unpaidInvoices = await (
                    from i in _context.Invoices
                    join p in _context.Patients on i.PatientId equals p.Id into patientGroup
                    from patient in patientGroup.DefaultIfEmpty()
                    where ((i.Amount) - (i.Payment)) > 0 && (i.IsCanceled == false || i.IsCanceled == null)
                    select new
                    {
                        InvoiceNo = i.InvoiceNo,
                        PatientName = ((patient.FirstName ?? "") + " " + (patient.LastName ?? "")).Trim(),
                        RemainingAmount = ((decimal?)i.Amount ?? 0m) - ((decimal?)i.Payment ?? 0m)
                    }
                ).ToListAsync();

                response.Status = 0;
                response.Data = new
                {
                    AppointmentCount = appointmentCount,
                    UnpaidInvoices = unpaidInvoices
                };
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<GetSubmitedInvoicesResponse> GetSubmitedInvoices(InvoiceFilterDto model)
        {
            try
            {
                var from = model.FromDate.Date;
                var to = model.ToDate.Date.AddDays(1).AddTicks(-1);

                var invoices = await _context.Invoices
                    .Where(i => i.CreatedOn >= from && i.CreatedOn <= to && (i.IsCanceled == false || i.IsCanceled == null))
                    .ToListAsync();

                var totalInvoices = invoices.Count;
                var totalReceiptAmount = invoices.Sum(i => i.Receipt);

                return new GetSubmitedInvoicesResponse
                {
                    Count = totalInvoices,
                    Receipt = totalReceiptAmount
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error calculating invoice summary: {ex.Message}");
            }
        }
    }
}
