using Clinic.Api.Application.DTOs.Expenses;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<string> SaveExpense(SaveExpenseDto model);
        Task<IEnumerable<ExpensesContext>> GetExpenses();
    }
}
