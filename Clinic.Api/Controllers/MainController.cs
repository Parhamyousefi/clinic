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
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> GetSections()
        {
            var result = await _mainService.GetSections();
            return Ok(result);
        }

        [HttpGet("getClinics")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> GetClinics()
        {
            var result = await _mainService.GetClinics();
            return Ok(result);
        }

        [HttpPost("saveJob")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> SaveJob(SaveJobDto model)
        {
            var result = await _mainService.SaveJob(model);
            return Ok(result);
        }

        [HttpGet("getJobs")]
        [Authorize("Admin", "Doctor", "Secretary")]
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
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _mainService.GetCountries();
            return Ok(result);
        }

        [HttpPost("saveProduct")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> SaveProduct(SaveProductDto model)
        {
            var result = await _mainService.SaveProduct(model);
            return Ok(result);
        }

        [HttpGet("getProducts")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mainService.GetProducts();
            return Ok(result);
        }

        [HttpGet("deleteProduct/{id}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mainService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost("saveNote")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> SaveNote(SaveNoteDto model)
        {
            var result = await _mainService.SaveNote(model);
            return Ok(result);
        }

        [HttpGet("getNotes/{patientId}")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> GetNotes(int patientId)
        {
            var result = await _mainService.GetNotes(patientId);
            return Ok(result);
        }

        [HttpGet("deleteNote/{noteId}")]
        [Authorize("Admin", "Doctor")]
        public async Task<IActionResult> DeleteNote(int noteId)
        {
            var result = await _mainService.DeleteNote(noteId);
            return Ok(result);
        }

        [HttpPost("saveDoctorSchedule")]
        [Authorize("Admin", "Doctor", "Secretary")]
        public async Task<IActionResult> SaveDoctorSchedule()
    }
}
