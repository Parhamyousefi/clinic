using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Appointments;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentsService;

        public TreatmentController(ITreatmentService treatmentsService)
        {
            _treatmentsService = treatmentsService;
        }

        [HttpPost("createAppointment")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> Create(CreateAppointmentDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _treatmentsService.CreateAppointmentAsync(model);
            return Ok(new { success = id, message = "Appointment Created Successfully" });
        }

        [HttpGet("deleteAppointment/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _treatmentsService.DeleteAppointment(id);
            return Ok(result);
        }

        [HttpPost("getAppointments")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetAppointments(GetAppointmentsDto model)
        {
            var result = await _treatmentsService.GetAppointments(model);
            return Ok(result);
        }

        [HttpGet("getTreatments/{appointmentId}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetTreatments(int appointmentId)
        {
            var result = await _treatmentsService.GetTreatments(appointmentId);

            return Ok(result);
        }

        [HttpPost("saveTreatment")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveTreatment(SaveTreatmentDto model)
        {
            var result = await _treatmentsService.SaveTreatment(model);

            return Ok(result);
        }

        [HttpGet("deleteTreatment/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteTreatment(int id)
        {
            var result = await _treatmentsService.DeleteTreatment(id);
            return Ok(result);
        }

        [HttpPost("getTodayAppointments")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetTodayAppointments(GetTodayAppointmentsDto model)
        {
            var result = await _treatmentsService.GetTodayAppointments(model);
            return Ok(result);
        }

        [HttpGet("getAppointmentTypes")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetAppointmentTypes()
        {
            var result = await _treatmentsService.GetAppointmentTypes();

            return Ok(result);
        }

        [HttpGet("getWeekAppointments")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetWeekAppointments()
        {
            var result = await _treatmentsService.GetWeekAppointments();
            return Ok(result);
        }
    }
}
