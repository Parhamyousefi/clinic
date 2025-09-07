using AutoMapper;
using Clinic.Api.Application.DTOs.Questions;
using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionService(ApplicationDbContext context, IMapper mapper)
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
                if (model.EditOrNew == -1)
                {
                    var questionValue = _mapper.Map<QuestionValuesContext>(model);
                    _context.QuestionValues.Add(questionValue);
                    await _context.SaveChangesAsync();
                    return "Successfully Saved QuestionValue";
                }
                else
                {
                    var existingQuestionValue = await _context.QuestionValues.FirstOrDefaultAsync(q => q.Id == model.EditOrNew);

                    if (existingQuestionValue == null)
                    {
                        throw new Exception("Question Value Not Found");
                    }

                    _mapper.Map(model, existingQuestionValue);
                    _context.QuestionValues.Update(existingQuestionValue);
                    await _context.SaveChangesAsync();
                    return "Question Value Update Successfully";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteQuestionValue(int id)
        {
            try
            {
                var questionValue = await _context.QuestionValues.FindAsync(id);
                if (questionValue == null)
                    throw new Exception("Question Value Not Found");

                _context.QuestionValues.Remove(questionValue);
                await _context.SaveChangesAsync();
                return "Question Value Deleted Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
