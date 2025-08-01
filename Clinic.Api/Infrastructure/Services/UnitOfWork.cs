using Clinic.Api.Application.Interfaces;
using Clinic.Api.Domain.Entities;
using Clinic.Api.Infrastructure.Data;

namespace Clinic.Api.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _ctx;
        public IRepository<UserContext> Users { get; }

        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Users = new Repository<UserContext>(ctx);
        }

        public async Task<int> SaveAsync() => await _ctx.SaveChangesAsync();
    }
}
