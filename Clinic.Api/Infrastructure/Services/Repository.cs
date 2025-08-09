using Clinic.Api.Application.Interfaces;
using Clinic.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _ctx;
        public Repository(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<T>> GetAllAsync() => await _ctx.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _ctx.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) => await _ctx.Set<T>().AddAsync(entity);
    }
}
