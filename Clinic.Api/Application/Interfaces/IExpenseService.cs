using Clinic.Api.Application.DTOs;
using Clinic.Api.Application.DTOs.Expenses;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<GlobalResponse> SaveExpense(SaveExpenseDto model);
        Task<IEnumerable<ExpensesContext>> GetExpenses();
    }
}
