using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Report;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

                var invoicesQuery = _context.Invoices
                    .Where(i => i.PractitionerId != null);

                if (fromDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn <= toDateTime.Value);

                var query = from invoice in invoicesQuery
                            join user in _context.Users
                                on invoice.PractitionerId equals user.Id
                            select new
                            {
                                user.FirstName,
                                user.LastName,
                                invoice.Receipt,
                                invoice.Payment,
                                invoice.TotalDiscount
                            };

                var result = await query
                    .GroupBy(x => new { x.FirstName, x.LastName })
                    .Select(g => new GetPractitionerIncomeReportResponse
                    {
                        PractitionerName = $"{g.Key.FirstName} {g.Key.LastName}",
                        TotalReceipt = g.Sum(x =>
                            (x.Receipt)
                            - (x.Payment)
                            - (x.TotalDiscount)
                        )
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

                var invoicesQuery = _context.Invoices
                    .Where(i => i.BusinessId != null);

                if (fromDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn <= toDateTime.Value);

                var query = from invoice in invoicesQuery
                            join business in _context.Businesses
                                on invoice.BusinessId equals business.Id
                            select new
                            {
                                business.Name,
                                invoice.Receipt,
                                invoice.Payment,
                                invoice.TotalDiscount
                            };

                var result = await query
                    .GroupBy(x => x.Name)
                    .Select(g => new GetBusinessIncomeReportResponse
                    {
                        BusinessName = g.Key,
                        TotalReceipt = g.Sum(x =>
                            (x.Receipt)
                            - (x.Payment)
                            - (x.TotalDiscount)
                        )
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

                var invoicesQuery = _context.Invoices
                    .Where(i => i.PractitionerId != null && i.BusinessId != null);

                if (fromDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn >= fromDateTime.Value);

                if (toDateTime.HasValue)
                    invoicesQuery = invoicesQuery.Where(i => i.CreatedOn <= toDateTime.Value);

                var query = from invoice in invoicesQuery
                            join user in _context.Users
                                on invoice.PractitionerId equals user.Id
                            join business in _context.Businesses
                                on invoice.BusinessId equals business.Id
                            select new
                            {
                                user.FirstName,
                                user.LastName,
                                business.Name,
                                invoice.Receipt,
                                invoice.Payment,
                                invoice.TotalDiscount
                            };

                var result = await query
                    .GroupBy(x => new { x.FirstName, x.LastName, x.Name })
                    .Select(g => new GetIncomeReportDetailResponse
                    {
                        PractitionerName = $"{g.Key.FirstName} {g.Key.LastName}",
                        BusinessName = g.Key.Name,
                        TotalReceipt = g.Sum(x =>
                            (x.Receipt)
                            - (x.Payment)
                            - (x.TotalDiscount)
                        )
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


        public async Task<GlobalResponse> GetOutPatientSummaryReport(OutPatientReportFilterDto model)
        {
            var response = new GlobalResponse();

            try
            {
                var fromDateTime = model.FromDate.Date.Add(TimeSpan.Parse(model.FromTime ?? "00:00:00"));
                var toDateTime = model.ToDate.Date.Add(TimeSpan.Parse(model.ToTime ?? "23:59:59"));

                var userIds = new List<int>();
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    userIds = model.UserId
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(u => int.Parse(u.Trim()))
                        .ToList();
                }

                var serviceIds = new List<int>();
                if (!string.IsNullOrEmpty(model.ServiceId))
                {
                    serviceIds = model.ServiceId
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => int.Parse(s.Trim()))
                        .ToList();
                }

                var productIds = new List<int>();
                if (!string.IsNullOrEmpty(model.Product))
                {
                    productIds = model.Product
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => int.Parse(p.Trim()))
                        .ToList();
                }

                var query = from invoice in _context.Invoices
                            join item in _context.InvoiceItems
                                on invoice.Id equals item.InvoiceId
                            where
                                invoice.CreatedOn >= fromDateTime &&
                                invoice.CreatedOn <= toDateTime &&
                                (userIds.Count == 0 || userIds.Contains(invoice.PractitionerId)) &&
                                (serviceIds.Count == 0 || (item.ItemId.HasValue && serviceIds.Contains(item.ItemId.Value))) &&
                                (productIds.Count == 0 || (item.ProductId.HasValue && productIds.Contains(item.ProductId.Value))) &&
                                (string.IsNullOrEmpty(model.IsPaid) ||
                                    (model.IsPaid == "1" && invoice.Receipt > 0) ||
                                    (model.IsPaid == "0" && (invoice.Receipt == null || invoice.Receipt == 0))) &&
                                (model.CreatorId == 0 || invoice.CreatorId == model.CreatorId)
                            select new
                            {
                                invoice.Id,
                                invoice.Amount,
                                invoice.TotalDiscount,
                                invoice.Payment,
                                invoice.Receipt,
                                invoice.BusinessAmount,
                                invoice.BusinessDebit,
                                invoice.IsCanceled
                            };

                var data = await query.ToListAsync();

                if (data == null || !data.Any())
                {
                    response.Status = 0;
                    response.Message = "Data Not Found";
                    response.Data = null;
                    return response;
                }

                var totalCount = data.Count;
                var canceledCount = data.Count(x => x.IsCanceled);
                var totalAmount = data.Sum(x => x.Amount);
                var totalDiscount = data.Sum(x => x.TotalDiscount);
                var totalReceivable = totalAmount - totalDiscount;
                var totalReceived = data.Sum(x => x.Receipt);
                var totalPaid = data.Sum(x => x.Payment);

                var netReceived = (totalReceived - totalPaid - totalDiscount);

                var totalUnreceived = totalReceivable - totalReceived;

                var totalOverReceived = totalReceived > totalReceivable
                    ? totalReceived - totalReceivable
                    : 0;

                response.Status = 1;
                response.Message = "Success";
                response.Data = new
                {
                    TotalCount = totalCount,
                    CanceledCount = canceledCount,
                    TotalAmount = totalAmount,
                    TotalDiscount = totalDiscount,
                    TotalReceivable = totalReceivable,
                    TotalReceived = totalReceived,
                    TotalPaid = totalPaid,
                    NetReceived = netReceived,
                    TotalUnreceived = totalUnreceived,
                    TotalOverReceived = totalOverReceived
                };

                return response;
            }
            catch (Exception ex)
            {
                response.Status = 3;
                response.Message = ex.Message;
                return response;
            }
        }


        public async Task<GlobalResponse> GetOutPatientReportBasedOnCreator(OutPatientReportFilterDto model)
        {
            var response = new GlobalResponse();

            try
            {
                var fromDateTime = model.FromDate.Date.Add(TimeSpan.Parse(model.FromTime ?? "00:00:00"));
                var toDateTime = model.ToDate.Date.Add(TimeSpan.Parse(model.ToTime ?? "23:59:59"));

                var userIds = new List<int>();
                if (!string.IsNullOrEmpty(model.UserId))
                {
                    userIds = model.UserId
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(u => int.Parse(u.Trim()))
                        .ToList();
                }

                var serviceIds = new List<int>();
                if (!string.IsNullOrEmpty(model.ServiceId))
                {
                    serviceIds = model.ServiceId
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => int.Parse(s.Trim()))
                        .ToList();
                }

                var productIds = new List<int>();
                if (!string.IsNullOrEmpty(model.Product))
                {
                    productIds = model.Product
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => int.Parse(p.Trim()))
                        .ToList();
                }

                var query = from invoice in _context.Invoices
                            join item in _context.InvoiceItems
                                on invoice.Id equals item.InvoiceId
                            join user in _context.Users
                                on invoice.CreatorId equals user.Id
                            where
                                invoice.CreatedOn >= fromDateTime &&
                                invoice.CreatedOn <= toDateTime &&
                                (userIds.Count == 0 || userIds.Contains(invoice.PractitionerId)) &&
                                (serviceIds.Count == 0 || (item.ItemId.HasValue && serviceIds.Contains(item.ItemId.Value))) &&
                                (productIds.Count == 0 || (item.ProductId.HasValue && productIds.Contains(item.ProductId.Value))) &&
                                (string.IsNullOrEmpty(model.Referral) || invoice.InvoiceTo == model.Referral) &&
                                (string.IsNullOrEmpty(model.IsPaid) ||
                                    (model.IsPaid == "1" && invoice.Receipt > 0) ||
                                    (model.IsPaid == "0" && (invoice.Receipt == null || invoice.Receipt == 0))) &&
                                (model.CreatorId == 0 || invoice.CreatorId == model.CreatorId)
                            select new
                            {
                                CreatorId = invoice.CreatorId,
                                CreatorName = user.FirstName + " " + user.LastName,
                                invoice.Amount,
                                invoice.TotalDiscount,
                                invoice.Payment,
                                invoice.Receipt,
                                invoice.IsCanceled
                            };

                var data = await query.ToListAsync();

                if (data == null || !data.Any())
                {
                    response.Status = 0;
                    response.Message = "No Data Found";
                    response.Data = null;
                    return response;
                }

                var totalCount = data.Count;
                var canceledCount = data.Count(x => x.IsCanceled);
                var totalAmount = data.Sum(x => x.Amount);
                var totalDiscount = data.Sum(x => x.TotalDiscount);
                var totalReceivable = totalAmount - totalDiscount;
                var totalReceived = data.Sum(x => x.Receipt);
                var totalPaid = data.Sum(x => x.Payment);

                var netReceived = (totalReceived - totalPaid - totalDiscount);

                var totalUnreceived = totalReceivable - totalReceived;

                var totalOverReceived = totalReceived > totalReceivable
                    ? totalReceived - totalReceivable
                    : 0;

                var groupedData = data
                    .GroupBy(x => new { x.CreatorId, x.CreatorName })
                    .Select(g => new
                    {
                        CreatorName = g.Key.CreatorName,
                        Count = totalCount,
                        TotalAmount = totalAmount,
                        TotalDiscount = totalDiscount,
                        TotalReceivable = totalReceivable,
                        TotalReceived = totalReceived,
                        TotalPaid = totalPaid,
                        NetReceived = netReceived,
                        TotalUnreceived = totalUnreceived,
                        TotalOverReceived = totalOverReceived
                    })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                response.Status = 1;
                response.Message = "Success";
                response.Data = groupedData;

                return response;
            }
            catch (Exception ex)
            {
                response.Status = 3;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<GetUnvisitedSummaryResponse> GetUnvisitedSummary(GetUnvisitedPatientsDto model)
        {
            try
            {
                var userIds = (model.UserIds ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                var businessIds = (model.BusinessIds ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                var query = _context.Appointments.AsQueryable();

                query = query.Where(a => a.Start.Date >= model.FromDate.Date && a.End.Date <= model.ToDate.Date);

                if (userIds.Any())
                    query = query.Where(a => a.PractitionerId.HasValue && userIds.Contains(a.PractitionerId.Value));

                if (businessIds.Any())
                    query = query.Where(a => a.BusinessId != null && businessIds.Contains(a.BusinessId.Value));

                query = query.Where(a => a.Arrived != null && a.Cancelled != null);

                var arrivedCount = await query.CountAsync(a => a.Arrived == 0);
                var cancelledCount = await query.CountAsync(a => a.Cancelled == true);

                var result = new GetUnvisitedSummaryResponse
                {
                    UnArrivedCount = arrivedCount,
                    CancelledCount = cancelledCount,
                    TotalCount = arrivedCount + cancelledCount
                };

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> GetUnvisitedDetails(GetUnvisitedPatientsDto model)
        {
            var response = new GlobalResponse();

            try
            {
                var fromDate = model.FromDate.Date;
                var toDate = model.ToDate.Date.AddDays(1).AddTicks(-1);

                var userIds = (model.UserIds ?? "")
                     .Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
                     .Where(id => id.HasValue)
                     .Select(id => id.Value)
                     .ToList();

                var businessIds = (model.BusinessIds ?? "")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                var query = _context.Appointments
                    .Where(a => a.Start >= fromDate && a.Start <= toDate)
                    .Where(a => a.Arrived == 0 || a.Cancelled == true);

                if (userIds.Any())
                    query = query.Where(a => a.PractitionerId.HasValue && userIds.Contains(a.PractitionerId.Value));

                if (businessIds.Any())
                    query = query.Where(a => a.BusinessId.HasValue && businessIds.Contains(a.BusinessId.Value));

                var data = await (
                    from a in query
                    join p in _context.Patients on a.PatientId equals p.Id
                    select new
                    {
                        Time = a.Start,
                        PatientName = (p.FirstName + " " + p.LastName).Trim(),
                        Reason = a.CancelNotes,
                        Notes = a.Note
                    }
                ).OrderByDescending(x => x.Time)
                 .ToListAsync();

                if (!data.Any())
                {
                    response.Status = 0;
                    response.Message = "No records found.";
                    return response;
                }

                response.Status = 1;
                response.Message = "Success";
                response.Data = data;

                return response;
            }
            catch (Exception ex)
            {
                response.Status = 3;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
