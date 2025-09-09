using AutoMapper;
using Clinic.Api.Application.DTOs.Expenses;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IReadTokenClaims _token;
        private readonly IMapper _mapper;

        public ExpenseService(ApplicationDbContext context, IReadTokenClaims token, IMapper mapper)
        {
            _context = context;
            _token = token;
            _mapper = mapper;
        }

        public async Task<string> SaveExpense(SaveExpenseDto model)
        {
            try
            {
                var userId = _token.GetUserId();

                if (model.EditOrNew == -1)
                {
                    var expense = _mapper.Map<ExpensesContext>(model);
                    expense.CreatedOn = DateTime.UtcNow;
                    expense.CreatorId = userId;
                    _context.Expenses.Add(expense);
                    await _context.SaveChangesAsync();
                    return "Expense Saved Successfully";
                }
                else
                {
                    var existingExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == model.EditOrNew);
                    if(existingExpense == null)
                    {
                        throw new Exception("Expense Not Found");
                    }

                    _mapper.Map(model, existingExpense);
                    existingExpense.ModifierId = userId;
                    existingExpense.LastUpdated = DateTime.UtcNow;
                    _context.Expenses.Update(existingExpense);
                    await _context.SaveChangesAsync();
                    return "Expense Saved Successfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ExpensesContext>> GetExpenses()
        {
            try
            {
                var expenses = await _context.Expenses.ToListAsync();
                return expenses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
