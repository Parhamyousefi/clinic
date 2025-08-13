using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("createAppointment")]
        [Authorize(Roles = "Admin,Practitioner")]
        public async Task<IActionResult> Create(CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _appointmentService.CreateAppointmentAsync(dto);
            return CreatedAtAction(nameof(Create), new { id }, new { id });
        }
    }
}
