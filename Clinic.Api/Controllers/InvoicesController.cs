using Clinic.Api.Application.DTOs.Invoices;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
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
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> SaveInvoices(SaveInvoicesDto model)
        {
            var result = await _invoicesService.SaveInvoices(model);
            return Ok(result);
        }

        [HttpGet("deleteInvoices/{id}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> DeleteInvoices(int id)
        {
            var result = await _invoicesService.DeleteInvoices(id);
            return Ok(result);
        }

        [HttpGet("getInvoices")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetInvoices()
        {
            var result = await _invoicesService.GetInvoices();
            return Ok(result);
        }

        [HttpPost("saveInvoiceItems")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveInvoiceItems(SaveInvoiceItemsDto model)
        {
            var result = await _invoicesService.SaveInvoiceItems(model);
            return Ok(result);
        }

        [HttpGet("deleteInvoiceItems/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteInvoiceItems(int id)
        {
            var result = await _invoicesService.DeleteInvoiceItems(id);
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
