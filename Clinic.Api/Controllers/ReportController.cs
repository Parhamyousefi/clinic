using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Report;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("getInvoicesByClinic")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetInvoicesByClinic(InvoiceFilterDto model)
        {
            var result = await _reportService.GetInvoicesByService(model);
            return Ok(result);
        }

        [HttpPost("getInvoicesByService")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetInvoicesByService(InvoiceFilterDto model)
        {
            var result = await _reportService.GetInvoicesByService(model);
            return Ok(result);
        }

        [HttpPost("getAppointmentsAndUnpaidInvoices")]
        [Authorize("Doctor","Admin")]
        public async Task<GlobalResponse> GetAppointmentsAndUnpaidInvoices(InvoiceFilterDto model)
        {
            var result = await _reportService.GetAppointmentsAndUnpaidInvoices(model);
            return result;
        }
    }
}
