using Clinic.Api.Application.DTOs.Payments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("savePayment")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SavePayment(SavePaymentDto model)
        {
            var result = await _paymentService.SavePayment(model);

            return Ok(result);
        }

        [HttpGet("getAllPayments")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetAllPayments();
            return Ok(result);
        }

        [HttpGet("getPayment/{patientId}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetPayment(int patientId)
        {
            var result = await _paymentService.GetPayment(patientId);
            return Ok(result);
        }

        [HttpGet("deletePayment/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _paymentService.DeletePayment(id);
            return Ok(result);
        }
    }
}
