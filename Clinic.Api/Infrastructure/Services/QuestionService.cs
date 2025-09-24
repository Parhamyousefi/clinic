using AutoMapper;
using Clinic.Api.Application.DTOs;
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
        private readonly IReadTokenClaims _token;

        public QuestionService(ApplicationDbContext context, IMapper mapper, IReadTokenClaims token)
        {
            _context = context;
            _mapper = mapper;
            _token = token;
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

        public async Task<GlobalResponse> SaveQuestionValue(SaveQuestionValueDto model)
        {
            var result = new GlobalResponse();
            var userId = _token.GetUserId();

            try
            {
                if (model.EditOrNew == -1)
                {
                    var questionValue = _mapper.Map<QuestionValuesContext>(model);
                    questionValue.CreatorId = userId;
                    _context.QuestionValues.Add(questionValue);
                    await _context.SaveChangesAsync();
                    result.Data = "QuestionValue Saved Successfully";
                    result.Status = 0;
                    return result;
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
                    result.Data = "QuestionValue Updated Successfully";
                    result.Status = 0;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GlobalResponse> DeleteQuestionValue(int id)
        {
            var result = new GlobalResponse();

            try
            {
                var questionValue = await _context.QuestionValues.FindAsync(id);
                if (questionValue == null)
                    throw new Exception("Question Value Not Found");

                _context.QuestionValues.Remove(questionValue);
                await _context.SaveChangesAsync();
                result.Data = "QuestionValue Deleted Successfully";
                result.Status = 0;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
