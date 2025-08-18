using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IQuestionsService
    {
        Task<IEnumerable<QuestionsContext>> GetQuestions();
        Task<string> SaveQuestionValue(SaveQuestionValueDto model);
    }
}
