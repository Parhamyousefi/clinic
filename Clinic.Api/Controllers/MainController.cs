using Clinic.Api.Application.DTOs.Main;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetSections()
        {
            var result = await _mainService.GetSections();
            return Ok(result);
        }

        [HttpPost("saveReceipts")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SaveReceipt(SaveReceiptsDto model)
        {
            var result = await _mainService.SaveReceipts(model);
            return Ok(result);
        }

        [HttpGet("getReceipts/{patientId?}")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetReceipts(int? patientId)
        {
            var result = await _mainService.GetReceipts(patientId);
            return Ok(result);
        }

        [HttpGet("deleteReceipts/{patientId}")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> DeleteReceipts(int patientId)
        {
            var result = await _mainService.DeleteReceipt(patientId);
            return Ok(result);
        }
    }
}
