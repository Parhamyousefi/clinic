using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentsService _treatmentsService;

        public TreatmentsController(ITreatmentsService treatmentsService)
        {
            _treatmentsService = treatmentsService;
        }

        [HttpPost("createAppointment")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create(CreateAppointmentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _treatmentsService.CreateAppointmentAsync(model);
            return Ok(new { success = id, message = "Appointment Created Successfully" });
        }

        [HttpGet("getAppointments/{clinicId}/{date?}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAppointments(int clinicId, DateTime? date)
        {
            var result = await _treatmentsService.GetAppointments(clinicId, date);
            return Ok(result);
        }

        [HttpGet("getTreatments/{appointmentId}")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetTreatments(int appointmentId)
        {
            var result = await _treatmentsService.GetTreatments(appointmentId);

            return Ok(result);
        }

        [HttpPost("saveTreatment")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SaveTreatment(SaveTreatmentsDto model)
        {
            var result = await _treatmentsService.SaveTreatment(model);

            return Ok(result);
        }

        [HttpPost("getTodayAppointments")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetTodayAppointments(GetTodayAppointmentsDto model)
        {
            var result = await _treatmentsService.GetTodayAppointments(model);
            return Ok(result);
        }
    }
}
