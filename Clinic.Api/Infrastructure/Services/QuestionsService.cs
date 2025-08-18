using AutoMapper;
using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionsContext>> GetQuestions()
        {
            try
            {
                var result = await _context.Questions.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> SaveQuestionValue(SaveQuestionValueDto model)
        {
            try
            {
                var questionValue = _mapper.Map<QuestionValuesContext>(model);
                _context.QuestionValues.Add(questionValue);
                await _context.SaveChangesAsync();
                return "Successfully Saved QuestionValue";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
