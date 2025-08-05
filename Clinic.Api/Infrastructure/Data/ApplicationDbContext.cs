using Clinic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserContext> Users { get; set; }
        public DbSet<UserPhonesContext> UserPhones { get; set; }
        public DbSet<RoleContext> RoleCtx { get; set; }
        public DbSet<RolesContext> Roles { get; set; }
        public DbSet<UserAppointmentsContext> UserAppointment { get; set; }
        public DbSet<UserBusinessesContext> UserBusinesses { get; set; }
        public DbSet<TreatmentsContext> Treatments { get; set; }
        public DbSet<WaitListBusinessesContext> WaitListBusinesses { get; set; }
        public DbSet<WaitListPractitionersContext> WaitListPractitioners { get; set; }
        public DbSet<WaitListsContext> WaitLists { get; set; }
        public DbSet<TimeExceptionsContext> TimeExceptions { get; set; }
        public DbSet<TitlesContext> Titles { get; set; }
        public DbSet<TimeExceptionTypesContext> TimeExceptionTypes { get; set; }
        public DbSet<StockAdjustmentTypesContext> StockAdjustmentTypes { get; set; }
        public DbSet<SMSSettingsContext> SMSSettings { get; set; }
        public DbSet<SectionsContext> Sections { get; set; }
        public DbSet<SchedulesContext> Schedules { get; set; }
        public DbSet<ReminderTypesContext> ReminderTypes { get; set; }
        public DbSet<RelationsContext> Relations { get; set; }
        public DbSet<RelatedPatientsContext> RelatedPatients { get; set; }
        public DbSet<ReferralSourcesContext> ReferralSources { get; set; }
        public DbSet<ReceiptTypesContext> ReceiptTypes { get; set; }
        public DbSet<ReceiptsContext> Receipts { get; set; }
        public DbSet<ReceiptInvoicesContext> ReceiptInvoices { get; set; }
        public DbSet<RecallTypesContext> RecallTypes { get; set; }
        public DbSet<RecallsContext> Recalls { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
