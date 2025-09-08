using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionsContext>> GetQuestions();
        Task<string> SaveQuestionValue(SaveQuestionValueDto model);
        Task<string> DeleteQuestionValue(int id);
    }
}
