using Clinic.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Api.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserContext> Users { get; set; }
        public DbSet<UserPhonesContext> UserPhones { get; set; }
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
        public DbSet<QuestionValuesContext> QuestionValues { get; set; }
        public DbSet<QuestionsContext> Questions { get; set; }
        public DbSet<ProductsContext> Products { get; set; }
        public DbSet<ProductCardexesContext> ProductCardexes { get; set; }
        public DbSet<PreAppointmentsContext> PreAppointments { get; set; }
        public DbSet<PractitionerTimeExceptionsContext> PractitionerTimeExceptions { get; set; }
        public DbSet<PhoneNoTypesContext> PhoneNoTypes { get; set; }
        public DbSet<PeriodsContext> Periods { get; set; }
        public DbSet<PaymentsContext> Payments { get; set; }
        public DbSet<PaymentInvoicesContext> PaymentInvoices { get; set; }
        public DbSet<PatientsContext> Patients { get; set; }
        public DbSet<PatientPhonesContext> PatientPhones { get; set; }
        public DbSet<PatientMessagesContext> PatientMessages { get; set; }
        public DbSet<PatientFieldsContext> PatientFields { get; set; }
        public DbSet<PatientFastMessagesContext> PatientFastMessages { get; set; }
        public DbSet<OutOfTurnExceptionsContext> OutOfTurnExceptions { get; set; }
        public DbSet<OnlineBookingsContext> OnlineBookings { get; set; }
        public DbSet<MessageCommentsContext> MessageComments { get; set; }
        public DbSet<MessageBoardsContext> MessageBoards { get; set; }
        public DbSet<MedicalNotesContext> MedicalNotes { get; set; }
        public DbSet<MedicalArtsContext> MedicalArts { get; set; }
        public DbSet<LoginHistoriesContext> LoginHistories { get; set; }
        public DbSet<LicencesContext> Licences { get; set; }
        public DbSet<LetterTemplatesContext> LetterTemplates { get; set; }
        public DbSet<LettersContext> Letters { get; set; }
        public DbSet<JobsContext> Jobs { get; set; }
        public DbSet<ItemCategoriesContext> ItemCategories { get; set; }
        public DbSet<InvoiceSettingsContext> InvoiceSettings { get; set; }
        public DbSet<InvoicesContext> Invoices { get; set; }
        public DbSet<InvoiceItemsContext> InvoiceItems { get; set; }
        public DbSet<InvoiceItemHistoriesContext> InvoiceItemHistories { get; set; }
        public DbSet<HolidaysContext> Holidays { get; set; }
        public DbSet<GeneralSettingsContext> GeneralSettings { get; set; }
        public DbSet<FileAttachmentsContext> FileAttachments { get; set; }
        public DbSet<ExpensesContext> Expenses { get; set; }
        public DbSet<ExpenseItemsContext> ExpenseItems { get; set; }
        public DbSet<DocumentsPrintingsContext> DocumentsPrintings { get; set; }
        public DbSet<DocumentNumbersContext> DocumentNumbers { get; set; }
        public DbSet<DateConvertContext> DateConverts { get; set; }
        public DbSet<ContriesContext> Contries { get; set; }
        public DbSet<ContactTypesContext> ContactTypes { get; set; }
        public DbSet<ContactsContext> Contacts { get; set; }
        public DbSet<ContactPhonesContext> ContactPhones { get; set; }
        public DbSet<CommunicationTypesContext> ComunicationTypes { get; set; }
        public DbSet<CommunicationsContext> Communications { get; set; }
        public DbSet<CommunicationDirectionsContext> CommunicationDirections { get; set; }
        public DbSet<CommunicationCategoriesContext> CommunicationCategories { get; set; }
        public DbSet<ChatMessageInfoesContext> ChatMessageInfoes { get; set; }
        public DbSet<BusinessServicesContext> BusinessServices { get; set; }
        public DbSet<BusinessesContext> Businesses { get; set; }
        public DbSet<BillableItemsContext> BillableItems { get; set; }
        public DbSet<AppointmentTypesContext> AppointmentTypes { get; set; }
        public DbSet<AppointmentTypePractitionersContext> AppointmentTypePractitioners { get; set; }
        public DbSet<AppointmentServicesContext> AppointmentServices { get; set; }
        public DbSet<AppointmentsContext> Appointments { get; set; }
        public DbSet<AppointmentRemindersContext> AppointmentReminders { get; set; }
        public DbSet<AppointmentCancelTypesContext> AppointmentCancelTypes { get; set; }
        public DbSet<AnswersContext> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DateConvertContext>()
     .HasNoKey()
     .ToView(null);
        }
    }
}
