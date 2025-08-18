using Clinic.Api.Application.DTOs.Patients;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("savePatient")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SavePatient(SavePatientDto model)
        {
            var result = await _patientService.SavePatient(model);

            return Ok(result);
        }

        [HttpGet("getPatients")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetPatients()
        {
            var result = await _patientService.GetPatients();

            return Ok(result);
        }
    }
}
