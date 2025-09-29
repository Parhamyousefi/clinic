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

        [HttpGet("getWeeklyAppointments")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetWeekAppointments()
        {
            var result = await _treatmentsService.GetWeekAppointments();
            return Ok(result);
        }

        [HttpGet("getBillableItems")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetBillableItems()
        {
            var result = await _treatmentsService.GetBillableItems();
            return Ok(result);
        }

        [HttpPost("saveBillableItem")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveBillableItem(SaveBillableItemsDto model)
        {
            var result = await _treatmentsService.SaveBillableItem(model);
            return Ok(result);
        }

        [HttpGet("deleteBillableItem/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteBillableItem(int id)
        {
            var result = await _treatmentsService.DeleteBillableItem(id);
            return Ok(result);
        }

        [HttpGet("getSectionPerService/{serviceId}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetSectionPerService(int serviceId)
        {
            var result = await _treatmentsService.GetSectionPerService(serviceId);
            return Ok(result);
        }

        [HttpGet("getQuestionsPerSection/{sectionId}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetQuestionsPerSection(int sectionId)
        {
            var result = await _treatmentsService.GetQuestionsPerSection(sectionId);
            return Ok(result);
        }

        [HttpGet("getAnswersPerQuestion/{questionId}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetAnswersPerQuestion(int questionId)
        {
            var result = await _treatmentsService.GetAnswersPerQuestion(questionId);
            return Ok(result);
        }

        [HttpGet("getPatientServices/{patientId}")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetPatientServices(int patientId)
        {
            var result = await _treatmentsService.GetPatientServices(patientId);
            return Ok(result);
        }
    }
}
