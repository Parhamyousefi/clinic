using Clinic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Clinic.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserContext> Users { get; set; }
        public DbSet<UserPhonesContext> UserPhonesContexts { get; set; }
        public DbSet<RoleContext> Roles { get; set; }
        public DbSet<RolesContext> RolesCtx { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleContext>().HasData(
       new RoleContext { Id = 1, Name = "Admin", Description = "System Administrator" }
      );
        }
    }
}
