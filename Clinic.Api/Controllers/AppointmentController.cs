using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create(CreateAppointmentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _appointmentService.CreateAppointmentAsync(model);
            return Ok(new { success = id, message = "Appointment Created Successfully" });
        }

        [HttpGet("getAppointments/{clinicId}/{date?}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAppointments(int clinicId, DateTime? date)
        {
            var appointments = await _appointmentService.GetAppointments(clinicId, date);
            return Ok(appointments);
        }
    }
}
