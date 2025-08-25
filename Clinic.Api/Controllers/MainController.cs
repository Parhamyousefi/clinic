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
    }
}
