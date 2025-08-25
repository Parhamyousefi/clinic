using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class MainService : IMainService
    {
        private readonly ApplicationDbContext _context;

        public MainService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionsContext>> GetSections()
        {
            try
            {
                var result = await _context.Sections.ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
