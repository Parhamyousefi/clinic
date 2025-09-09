using Clinic.Api.Application.DTOs.Expenses;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("saveExpense")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> SaveExpense(SaveExpenseDto model)
        {
            var result = await _expenseService.SaveExpense(model);
            return Ok(result);
        }

        [HttpGet("getExpenses")]
        [Authorize("Admin","Doctor")]
        public async Task<IActionResult> GetExpenses()
        {
            var result = await _expenseService.GetExpenses();
            return Ok(result);
        }
    }
}
