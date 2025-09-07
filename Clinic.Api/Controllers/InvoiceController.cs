using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoicesService;

        public InvoiceController(IInvoiceService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        [HttpPost("saveInvoice")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> SaveInvoice(SaveInvoiceDto model)
        {
            var result = await _invoicesService.SaveInvoice(model);
            return Ok(result);
        }

        [HttpGet("deleteInvoice/{id}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var result = await _invoicesService.DeleteInvoice(id);
            return Ok(result);
        }

        [HttpGet("getInvoices")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await _invoicesService.GetInvoices();
            return Ok(result);
        }

        [HttpPost("saveInvoiceItem")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveInvoiceItem(SaveInvoiceItemDto model)
        {
            var result = await _invoicesService.SaveInvoiceItem(model);
            return Ok(result);
        }

        [HttpGet("deleteInvoiceItem/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteInvoiceItem(int id)
        {
            var result = await _invoicesService.DeleteInvoiceItem(id);
            return Ok(result);
        }

        [HttpGet("getInvoiceItems")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetInvoiceItems()
        {
            var result = await _invoicesService.GetInvoiceItems();
            return Ok(result);
        }
    }
}
