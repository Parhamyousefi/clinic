using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;

        public InvoicesController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        [HttpPost("saveInvoices")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SaveInvoices(SaveInvoicesDto model)
        {
            var result = await _invoicesService.SaveInvoices(model);
            return Ok(result);
        }

        [HttpGet("getInvoices")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await _invoicesService.GetInvoices();
            return Ok(result);
        }

        [HttpPost("saveInvoiceItems")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SaveInvoiceItems(SaveInvoiceItemsDto model)
        {
            var result = await _invoicesService.SaveInvoiceItems(model);
            return Ok(result);
        }

        [HttpGet("getInvoiceItems")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetInvoiceItems()
        {
            var result = await _invoicesService.GetInvoiceItems();
            return Ok(result);
        }
    }
}
