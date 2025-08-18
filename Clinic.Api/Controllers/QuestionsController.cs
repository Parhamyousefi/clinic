using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpGet("getQuestions")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> GetQuestions()
        {
            var result = await _questionsService.GetQuestions();
            return Ok(result);
        }

        [HttpPost("saveQuestionValue")]
        [Authorize(Roles ="Admin,Doctor")]
        public async Task<IActionResult> SaveQuestionValue(SaveQuestionValueDto model)
        {
            var result = await _questionsService.SaveQuestionValue(model);

            return Ok(result);
        }
    }
}
