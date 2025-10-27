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
                                where inv.CreatedOn >= filter.FromDate.Date && inv.CreatedOn <= filter.ToDate.Date
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
                                where inv.CreatedOn >= filter.FromDate.Date && inv.CreatedOn <= filter.ToDate.Date
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

        public async Task<GlobalResponse> GetSubmitedAppointments(InvoiceFilterDto model)
        {
            var response = new GlobalResponse();

            try
            {
                var fromDate = model.FromDate.Date;
                var toDate = model.ToDate.Date;

                var appointmentCount = await _context.Appointments
                    .CountAsync(a => a.Start >= fromDate && a.End <= toDate && (a.Cancelled == false || a.Cancelled == null));

                var cancelledOrNoShowCount = await _context.Appointments
                    .CountAsync(a => a.Start >= fromDate && a.End <= toDate &&
                                     (a.Cancelled == true || a.Arrived == 0));

                response.Status = 0;
                response.Data = new
                {
                    AppointmentCount = appointmentCount,
                    CancelledOrNoShowCount = cancelledOrNoShowCount,
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

        public async Task<IEnumerable<GetUnpaidInvoicesResponse>> GetUnpaidInvoices(InvoiceFilterDto model)
        {
            try
            {
                var from = model.FromDate.Date;
                var to = model.ToDate.Date.AddDays(1).AddTicks(-1);

                var invoices = await _context.Invoices
                      .Where(i => i.CreatedOn >= from && i.CreatedOn <= to && (i.IsCanceled == false || i.IsCanceled == null))
          .Join(_context.Patients,
            inv => inv.PatientId,
            pat => pat.Id,
            (inv, pat) => new
            {
                inv.InvoiceNo,
                pat.FirstName,
                pat.LastName,
                inv.Amount,
                inv.Receipt
            })
        .ToListAsync();

                var unpaidInvoices = invoices
                    .Select(i => new GetUnpaidInvoicesResponse
                    {
                        InvoiceNo = i.InvoiceNo,
                        PatientFullName = $"{i.FirstName} {i.LastName}",
                        RemainingAmount = ((decimal?)i.Amount ?? 0m) - ((decimal?)i.Receipt ?? 0m)
                    })
                    .Where(r => r.RemainingAmount != 0)
                    .ToList();

                return unpaidInvoices;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<GetPractitionerIncomeReportResponse>> GetPractitionerIncome(IncomeReportFilterDto model)
        {
            try
            {
                DateTime? fromDateTime = null;
                DateTime? toDateTime = null;

                if (model.From.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.FromTime) && TimeSpan.TryParse(model.FromTime, out var fromTs))
                        fromDateTime = model.From.Value.Date.Add(fromTs);
                    else
                        fromDateTime = model.From.Value.Date;
                }

                if (model.To.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.ToTime) && TimeSpan.TryParse(model.ToTime, out var toTs))
                        toDateTime = model.To.Value.Date.Add(toTs);
                    else
                        toDateTime = model.To.Value.Date.AddDays(1).AddTicks(-1);
                }

                var query = _context.Invoices
                    .Where(i => i.PractitionerId != null);

                if (fromDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn <= toDateTime.Value);

                var result = await query
                    .Join(_context.Users,
                        invoice => invoice.PractitionerId,
                        user => user.Id,
                        (invoice, user) => new
                        {
                            user.FirstName,
                            user.LastName,
                            invoice.Receipt
                        })
                    .GroupBy(x => new { x.FirstName, x.LastName })
                    .Select(g => new GetPractitionerIncomeReportResponse
                    {
                        PractitionerName = $"{g.Key.FirstName} {g.Key.LastName}",
                        TotalReceipt = g.Sum(x => x.Receipt)
                    })
                    .OrderByDescending(x => x.TotalReceipt)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<IEnumerable<GetBusinessIncomeReportResponse>> GetBusinessIncome(IncomeReportFilterDto model)
        {
            try
            {
                DateTime? fromDateTime = null;
                DateTime? toDateTime = null;

                if (model.From.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.FromTime) && TimeSpan.TryParse(model.FromTime, out var fromTs))
                        fromDateTime = model.From.Value.Date.Add(fromTs);
                    else
                        fromDateTime = model.From.Value.Date;
                }

                if (model.To.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.ToTime) && TimeSpan.TryParse(model.ToTime, out var toTs))
                        toDateTime = model.To.Value.Date.Add(toTs);
                    else
                        toDateTime = model.To.Value.Date.AddDays(1).AddTicks(-1);
                }

                var query = _context.Invoices
                    .Where(i => i.BusinessId != null);

                if (fromDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn <= toDateTime.Value);

                var result = await query
                    .Join(_context.Businesses,
                        invoice => invoice.BusinessId,
                        business => business.Id,
                        (invoice, business) => new
                        {
                            business.Name,
                            invoice.Receipt
                        })
                    .GroupBy(x => x.Name)
                    .Select(g => new GetBusinessIncomeReportResponse
                    {
                        BusinessName = g.Key,
                        TotalReceipt = g.Sum(x => (decimal?)(x.Receipt)) ?? 0
                    })
                    .OrderByDescending(x => x.TotalReceipt)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<IEnumerable<GetIncomeReportDetailResponse>> GetIncomeReportDetails(IncomeReportFilterDto model)
        {
            try
            {
                DateTime? fromDateTime = null;
                DateTime? toDateTime = null;

                if (model.From.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.FromTime) && TimeSpan.TryParse(model.FromTime, out var fromTs))
                        fromDateTime = model.From.Value.Date.Add(fromTs);
                    else
                        fromDateTime = model.From.Value.Date;
                }

                if (model.To.HasValue)
                {
                    if (!string.IsNullOrEmpty(model.ToTime) && TimeSpan.TryParse(model.ToTime, out var toTs))
                        toDateTime = model.To.Value.Date.Add(toTs);
                    else
                        toDateTime = model.To.Value.Date.AddDays(1).AddTicks(-1);
                }

                var query = _context.Invoices
                    .Where(i => i.PractitionerId != null && i.BusinessId != null);

                if (fromDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    query = query.Where(i => i.CreatedOn <= toDateTime.Value);

                var result = await query
                    .Join(_context.Users,
                        invoice => invoice.PractitionerId,
                        user => user.Id,
                        (invoice, user) => new { invoice, user })
                    .Join(_context.Businesses,
                        combined => combined.invoice.BusinessId,
                        business => business.Id,
                        (combined, business) => new
                        {
                            combined.user.FirstName,
                            combined.user.LastName,
                            business.Name,
                            combined.invoice.Receipt
                        })
                    .GroupBy(x => new { x.FirstName, x.LastName, x.Name })
                    .Select(g => new GetIncomeReportDetailResponse
                    {
                        PractitionerName = $"{g.Key.FirstName} {g.Key.LastName}",
                        BusinessName = g.Key.Name,
                        TotalReceipt = g.Sum(x => (decimal?)(x.Receipt)) ?? 0
                    })
                    .OrderByDescending(x => x.TotalReceipt)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
