using Clinic.Api.Domain.Entities;

namespace Clinic.Api.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<UserContext> Users { get; }
        Task<int> SaveAsync();
    }
}
