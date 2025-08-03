using Clinic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Clinic.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserContext> Users { get; set; }
        public DbSet<UserPhonesContext> UserPhones { get; set; }
        public DbSet<RoleContext> Roles { get; set; }
        public DbSet<RolesContext> RolesCtx { get; set; }
        public DbSet<UserAppointmentsContext> UserAppointment { get; set; }
        public DbSet<UserBusinessesContext> UserBusinesses { get; set; }
        public DbSet<TreatmentsContext> Treatments { get; set; }
        public DbSet<WaitListBusinessesContext> WaitListBusinesses { get; set; }
        public DbSet<WaitListPractitionersContext> WaitListPractitioners { get; set; }
        public DbSet<WaitListsContext> WaitLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RoleContext>().HasData(
       new RoleContext { Id = 1, Name = "Admin", Description = "System Administrator" }
      );
        }
    }
}
