using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainService _mainService;

        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpGet("getSections")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetSections()
        {
            var result = await _mainService.GetSections();
            return Ok(result);
        }

        [HttpPost("saveReceipt")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveReceipt(SaveReceiptDto model)
        {
            var result = await _mainService.SaveReceipt(model);
            return Ok(result);
        }

        [HttpGet("getReceipts/{patientId?}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetReceipts(int? patientId)
        {
            var result = await _mainService.GetReceipts(patientId);
            return Ok(result);
        }

        [HttpGet("deleteReceipt/{patientId}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteReceipt(int patientId)
        {
            var result = await _mainService.DeleteReceipt(patientId);
            return Ok(result);
        }

        [HttpGet("getClinics")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetClinics()
        {
            var result = await _mainService.GetClinics();
            return Ok(result);
        }

        [HttpPost("saveJob")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> SaveJob(SaveJobDto model)
        {
            var result = await _mainService.SaveJob(model);
            return Ok(result);
        }

        [HttpGet("getJobs")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> GetJobs()
        {
            var result = await _mainService.GetJobs();
            return Ok(result);
        }

        [HttpGet("deleteJob/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var result = await _mainService.DeleteJob(id);
            return Ok(result);
        }
        
        [HttpGet("getCountries")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _mainService.GetCountries();
            return Ok(result);
        }
    }
}
