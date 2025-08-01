using Clinic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserContext> Users => Set<UserContext>();
    }
}
