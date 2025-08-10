using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Api.Migrations
{
    /// <inheritdoc />
    public partial class FinalTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RolesCtx");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptDiscount",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowPayLater",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowPayOverBalance",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowReceiptOverBalance",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentTypeCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentTypeDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentTypeView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AppointmentView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AttachmentCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AttachmentDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AttachmentView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BillableItemCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BillableItemDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BillableItemView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BusinessView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CanAcceptItem",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CashierByCashAndETFPosReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChangeInvoiceAfterReceive",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ChangePatientRecordStatus",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContactCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContactDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContactView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DiscountReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpenseCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpenseDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpenseReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExpenseView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FirstEncounterReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GeneralSettingCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GeneralSettingView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HolidayCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HolidayDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HolidayView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InInvoiceReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceCancel",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceDiscount",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceItemChangeReport",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InvoiceView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ItemCategoryCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ItemCategoryDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ItemCategoryView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JobCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JobDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "JobView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LetterCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LetterDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LetterTemplateCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LetterTemplateDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LetterTemplateView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LetterView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalAlertCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalAlertDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalAlertUpdate",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalRecordSend",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MedicalRecordView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MergePatients",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifierId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotArraivedPatientsReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutInvoiceReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutOfTurnExceptionCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutOfTurnExceptionDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OutOfTurnExceptionView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientFieldCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientFieldView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentAllowEdit",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PractitionerReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductCardexCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ProductView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptAllowEdit",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptPaymentReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReceiptView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Report",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RoleCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RoleDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RoleView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SMSSettingCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SMSSettingView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SetAppointmentPermission",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Setting",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SummaryReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TimeExceptionCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TimeExceptionDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TimeExceptionView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TotdayAppointmentView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentTemplateCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentTemplateDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentTemplateView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TreatmentView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UnChangeInvoiceReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserCreateAndUpdate",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserDelete",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserView",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VisitReport",
                table: "Roles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WatingReport",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Question_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentCancelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentCancelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultReminderTypeId = table.Column<int>(type: "int", nullable: false),
                    ReminderPeriod = table.Column<int>(type: "int", nullable: false),
                    SkipWeekends = table.Column<bool>(type: "bit", nullable: false),
                    ReminderTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentConfirmationSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentConfirmationContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentConfirmationHideAddress = table.Column<bool>(type: "bit", nullable: false),
                    EmailReminderEnabled = table.Column<bool>(type: "bit", nullable: false),
                    EmailReminderSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailReminderContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMSReminderEnabled = table.Column<bool>(type: "bit", nullable: false),
                    SMSReminderText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentReminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepeatId = table.Column<int>(type: "int", nullable: true),
                    RepeatEvery = table.Column<int>(type: "int", nullable: true),
                    EndsAfter = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrived = table.Column<int>(type: "int", nullable: false),
                    WaitListId = table.Column<int>(type: "int", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentCancelTypeId = table.Column<int>(type: "int", nullable: true),
                    CancelNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnavailbleBlock = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAllDay = table.Column<bool>(type: "bit", nullable: false),
                    SendReminder = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentSMS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IgnoreDidNotCome = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ByInvoice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    BillableItemId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypePractitioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypePractitioners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    MaximumNumberOfPatients = table.Column<int>(type: "int", nullable: false),
                    RelatedBillableItemId = table.Column<int>(type: "int", nullable: true),
                    RelatedBillableItem2Id = table.Column<int>(type: "int", nullable: true),
                    RelatedBillableItem3Id = table.Column<int>(type: "int", nullable: true),
                    DefaultTreatmentNoteTemplate = table.Column<int>(type: "int", nullable: true),
                    RelatedProductId = table.Column<int>(type: "int", nullable: true),
                    RelatedProduct2Id = table.Column<int>(type: "int", nullable: true),
                    RelatedProduct3Id = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendBookingConfirmationEmail = table.Column<bool>(type: "bit", nullable: false),
                    SendReminderEmail = table.Column<bool>(type: "bit", nullable: false),
                    ShowInOnlineBookings = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    IsFirstEncounter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsOther = table.Column<bool>(type: "bit", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AllowEditPrice = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    TreatmentTemplateId = table.Column<int>(type: "int", nullable: true),
                    ForceOneInvoice = table.Column<bool>(type: "bit", nullable: false),
                    IsTreatmentDataRequired = table.Column<bool>(type: "bit", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: true),
                    OrderInItemCategory = table.Column<int>(type: "int", nullable: true),
                    AutoCopyTreatment = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NeedAccept = table.Column<bool>(type: "bit", nullable: false),
                    LastTimeColor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayInOnlineBooking = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zoom = table.Column<int>(type: "int", nullable: true),
                    InfoEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsServiceBase = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ShowInvoiceInRecord = table.Column<bool>(type: "bit", nullable: false),
                    CheckScheduleOnInvoice = table.Column<bool>(type: "bit", nullable: false),
                    IsInPatient = table.Column<bool>(type: "bit", nullable: false),
                    SMSEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentByOutOfRange = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    BillableItemId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessageInfoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    UserFromId = table.Column<int>(type: "int", nullable: false),
                    UserToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessageInfoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationDirections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationDirections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationTypeId = table.Column<int>(type: "int", nullable: false),
                    CommunicationCategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CommunicationDirectionId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComunicationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunicationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    PhoneNoTypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNoType_Id = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsPrintings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LogoFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoHeight = table.Column<int>(type: "int", nullable: false),
                    DisplayLogoOnInvoice = table.Column<bool>(type: "bit", nullable: false),
                    InvoicePageSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopMargin = table.Column<int>(type: "int", nullable: false),
                    AccountStatments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowLogoOnLetters = table.Column<bool>(type: "bit", nullable: false),
                    SpaceUnderneathLogoOnLetters = table.Column<int>(type: "int", nullable: false),
                    TopMarginOnLetters = table.Column<int>(type: "int", nullable: false),
                    BottomMarginLetters = table.Column<int>(type: "int", nullable: false),
                    LeftMarginLetters = table.Column<int>(type: "int", nullable: false),
                    RightMarginLetters = table.Column<int>(type: "int", nullable: false),
                    DisplayLogoOnTreatment = table.Column<bool>(type: "bit", nullable: false),
                    HideUnSelectedCheckBoxesOnTreadtment = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentPageSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopMarginOnTreatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentsPrintings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitCostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ExpenseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileContent = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAttachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PractitionerCanOnlyReadLettersTheyAuthoredThemselves = table.Column<bool>(type: "bit", nullable: false),
                    PractitionerCannotSeeAnyFinancialDetails = table.Column<bool>(type: "bit", nullable: false),
                    ReceptionistsCanOnlyReadLettersTheyAuthoredThemselves = table.Column<bool>(type: "bit", nullable: false),
                    ReceptionistsCanViewFileAttachment = table.Column<bool>(type: "bit", nullable: false),
                    TimeSlotHeight = table.Column<int>(type: "int", nullable: false),
                    MultipleAppointments = table.Column<bool>(type: "bit", nullable: false),
                    ShowCurrentTimeIndicator = table.Column<bool>(type: "bit", nullable: false),
                    EmailFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailOnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    BirthDateOnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    Insurer1OnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    Insurer2OnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    Referr1OnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    Referr2OnAppointment = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zoom = table.Column<int>(type: "int", nullable: true),
                    SetPayableAmountInNewPaymentCash = table.Column<bool>(type: "bit", nullable: false),
                    DisallowOutOfTurnWhenHaveTime = table.Column<bool>(type: "bit", nullable: false),
                    CheckInvoiceDateByPractitionerSchedule = table.Column<bool>(type: "bit", nullable: false),
                    PatientCodeStartFrom = table.Column<int>(type: "int", nullable: false),
                    SetReceivebleAmountInNewReceiptBank = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    HolidayColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmptyDayColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullDayColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotFullDayColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowPatientNotes = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItemHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    OldQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NewQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItemHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsLock = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    InvoiceTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraPatientInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceBillStatusId = table.Column<int>(type: "int", nullable: true),
                    AllowPayLater = table.Column<bool>(type: "bit", nullable: false),
                    UserAllowPayLaterId = table.Column<int>(type: "int", nullable: true),
                    Receipt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BillStatus = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    BusinessDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    RecordStateId = table.Column<int>(type: "int", nullable: false),
                    AnesthesiaTechnicianId = table.Column<int>(type: "int", nullable: true),
                    ElectroTechnicianId = table.Column<int>(type: "int", nullable: true),
                    IsFirstInvoice = table.Column<bool>(type: "bit", nullable: false),
                    Anesthesia = table.Column<bool>(type: "bit", nullable: false),
                    BusinessAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AcceptDiscount = table.Column<bool>(type: "bit", nullable: false),
                    AssistantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingInvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    ExtraBusinessInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowBusinessContactInformation = table.Column<bool>(type: "bit", nullable: false),
                    ShowPatientDOB = table.Column<bool>(type: "bit", nullable: false),
                    HideLogoAndLetterHead = table.Column<bool>(type: "bit", nullable: false),
                    ShowNextAppointmentTime = table.Column<bool>(type: "bit", nullable: false),
                    OfferText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingInvoiceSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingInvoiceContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingOutstandingInvoiceToPatientSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingOutstandingInvoiceToPatientContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingPaidInvoice3rdPartySubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingPaidInvoice3rdPartyContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingOutstandingInvoiceTo3rdPartySubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailingOutstandingInvoiceTo3rdPartyContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    DefaultClosed = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LetterTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Template = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalArts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderOf = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalArts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MessageBoard_Id = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOnlineBookingsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaxAppointmentsPerDaySegment = table.Column<int>(type: "int", nullable: false),
                    MinimumAdvanceTimeRequiredForBookings = table.Column<int>(type: "int", nullable: false),
                    MinimumNoticeForCancellations = table.Column<int>(type: "int", nullable: false),
                    SMSBookingNotifications = table.Column<bool>(type: "bit", nullable: false),
                    EmailBookingNotifications = table.Column<bool>(type: "bit", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowPrice = table.Column<bool>(type: "bit", nullable: false),
                    ShowAppointmentDuration = table.Column<bool>(type: "bit", nullable: false),
                    RequireAddressOfPatient = table.Column<bool>(type: "bit", nullable: false),
                    TimeSelectionInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineBookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutOfTurnExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrigoryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    OutOfTurn = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutOfTurnExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientFastMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Params = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false),
                    ProviderMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFastMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    FatherName = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<int>(type: "int", nullable: true),
                    RelatedPatients = table.Column<int>(type: "int", nullable: true),
                    PatientPhones = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<int>(type: "int", nullable: true),
                    Address2 = table.Column<int>(type: "int", nullable: true),
                    Address3 = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: true),
                    PostCode = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ReminderTypeId = table.Column<int>(type: "int", nullable: true),
                    UnsubscribeFromSMSMarketing = table.Column<int>(type: "int", nullable: true),
                    ReceiveBookingConfirmationEmails = table.Column<int>(type: "int", nullable: true),
                    InvoiceTo = table.Column<int>(type: "int", nullable: true),
                    EmailInvoiceTo = table.Column<int>(type: "int", nullable: true),
                    InvoiceExtraInformation = table.Column<int>(type: "int", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    EmergencyContact = table.Column<int>(type: "int", nullable: true),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: true),
                    ReferringDoctorId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<int>(type: "int", nullable: true),
                    ReferringInsurerId = table.Column<int>(type: "int", nullable: true),
                    ReferringInsurer2Id = table.Column<int>(type: "int", nullable: true),
                    ReferringInpatientInsurerId = table.Column<int>(type: "int", nullable: true),
                    ReferringContactId = table.Column<int>(type: "int", nullable: true),
                    ReferringContact2Id = table.Column<int>(type: "int", nullable: true),
                    ReferringPatientId = table.Column<int>(type: "int", nullable: true),
                    NationalCode = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PhoneNoTypeId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ReminderTypeId = table.Column<int>(type: "int", nullable: true),
                    UnsubscribeFromSMSMarketing = table.Column<bool>(type: "bit", nullable: false),
                    ReceiveBookingConfirmationEmails = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailInvoiceTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceExtraInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferringDoctorId = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferringInsurerId = table.Column<int>(type: "int", nullable: true),
                    ReferringInsurer2Id = table.Column<int>(type: "int", nullable: true),
                    ReferringContactId = table.Column<int>(type: "int", nullable: true),
                    ReferringContact2Id = table.Column<int>(type: "int", nullable: true),
                    ReferringPatientId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientCode = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: true),
                    ReferringInpatientInsurerId = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OutBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Paperless = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EFTPos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Other = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PractitionerTimeExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerTimeExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    AppointmentTypeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreAppointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCardexes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockAdjustmentTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCardexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    normalAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    defaultAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    masterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    canCopy = table.Column<bool>(type: "bit", nullable: false),
                    canFocusEnd = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    selectedValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    RecallTypeId = table.Column<int>(type: "int", nullable: false),
                    RecallOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recalled = table.Column<bool>(type: "bit", nullable: false),
                    RecalledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecallTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecallIn = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecallTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptInvoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptNo = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EFTPos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Other = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    ReceiptTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferralSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferralSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelatedPatients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RelationPatientId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedPatients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReminderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReminderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    FromTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBreak = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AppointmentCancelTypes");

            migrationBuilder.DropTable(
                name: "AppointmentReminders");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentServices");

            migrationBuilder.DropTable(
                name: "AppointmentTypePractitioners");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "BillableItems");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "BusinessServices");

            migrationBuilder.DropTable(
                name: "ChatMessageInfoes");

            migrationBuilder.DropTable(
                name: "CommunicationCategories");

            migrationBuilder.DropTable(
                name: "CommunicationDirections");

            migrationBuilder.DropTable(
                name: "Communications");

            migrationBuilder.DropTable(
                name: "ComunicationTypes");

            migrationBuilder.DropTable(
                name: "ContactPhones");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactTypes");

            migrationBuilder.DropTable(
                name: "Contries");

            migrationBuilder.DropTable(
                name: "DocumentNumbers");

            migrationBuilder.DropTable(
                name: "DocumentsPrintings");

            migrationBuilder.DropTable(
                name: "ExpenseItems");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "FileAttachments");

            migrationBuilder.DropTable(
                name: "GeneralSettings");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "InvoiceItemHistories");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "InvoiceSettings");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "LetterTemplates");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "LoginHistories");

            migrationBuilder.DropTable(
                name: "MedicalArts");

            migrationBuilder.DropTable(
                name: "MedicalNotes");

            migrationBuilder.DropTable(
                name: "MessageBoards");

            migrationBuilder.DropTable(
                name: "MessageComments");

            migrationBuilder.DropTable(
                name: "OnlineBookings");

            migrationBuilder.DropTable(
                name: "OutOfTurnExceptions");

            migrationBuilder.DropTable(
                name: "PatientFastMessages");

            migrationBuilder.DropTable(
                name: "PatientFields");

            migrationBuilder.DropTable(
                name: "PatientMessages");

            migrationBuilder.DropTable(
                name: "PatientPhones");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PaymentInvoices");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "PhoneNoTypes");

            migrationBuilder.DropTable(
                name: "PractitionerTimeExceptions");

            migrationBuilder.DropTable(
                name: "PreAppointments");

            migrationBuilder.DropTable(
                name: "ProductCardexes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "QuestionValues");

            migrationBuilder.DropTable(
                name: "Recalls");

            migrationBuilder.DropTable(
                name: "RecallTypes");

            migrationBuilder.DropTable(
                name: "ReceiptInvoices");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "ReceiptTypes");

            migrationBuilder.DropTable(
                name: "ReferralSources");

            migrationBuilder.DropTable(
                name: "RelatedPatients");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "ReminderTypes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropColumn(
                name: "AcceptDiscount",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AllowPayLater",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AllowPayOverBalance",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AllowReceiptOverBalance",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentTypeCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentTypeDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentTypeView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppointmentView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AttachmentCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AttachmentDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AttachmentView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BillableItemCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BillableItemDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BillableItemView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BusinessCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BusinessDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "BusinessView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CanAcceptItem",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CashierByCashAndETFPosReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ChangeInvoiceAfterReceive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ChangePatientRecordStatus",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ContactCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ContactDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ContactView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DiscountReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ExpenseCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ExpenseDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ExpenseReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ExpenseView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "FirstEncounterReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "GeneralSettingCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "GeneralSettingView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "HolidayCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "HolidayDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "HolidayView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InInvoiceReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceCancel",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceDiscount",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceItemChangeReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "InvoiceView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ItemCategoryCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ItemCategoryDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ItemCategoryView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "JobCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "JobDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "JobView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterTemplateCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterTemplateDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterTemplateView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LetterView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MedicalAlertCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MedicalAlertDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MedicalAlertUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MedicalRecordSend",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MedicalRecordView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "MergePatients",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "NotArraivedPatientsReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "OutInvoiceReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "OutOfTurnExceptionCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "OutOfTurnExceptionDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "OutOfTurnExceptionView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PatientCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PatientDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PatientFieldCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PatientFieldView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PatientView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PaymentAllowEdit",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PaymentCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PaymentDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PaymentReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PaymentView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PractitionerReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProductCardexCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProductCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProductDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ProductView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptAllowEdit",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptPaymentReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ReceiptView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Report",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SMSSettingCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SMSSettingView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SetAppointmentPermission",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Setting",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SummaryReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TimeExceptionCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TimeExceptionDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TimeExceptionView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TotdayAppointmentView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentTemplateCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentTemplateDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentTemplateView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "TreatmentView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UnChangeInvoiceReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserCreateAndUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserDelete",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserView",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "VisitReport",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "WatingReport",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RolesCtx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptDiscount = table.Column<bool>(type: "bit", nullable: false),
                    AllowPayLater = table.Column<bool>(type: "bit", nullable: false),
                    AllowPayOverBalance = table.Column<bool>(type: "bit", nullable: false),
                    AllowReceiptOverBalance = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeDelete = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeView = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentView = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentView = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemDelete = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemView = table.Column<bool>(type: "bit", nullable: false),
                    BusinessCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    BusinessDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessView = table.Column<bool>(type: "bit", nullable: false),
                    CanAcceptItem = table.Column<bool>(type: "bit", nullable: false),
                    CashierByCashAndETFPosReport = table.Column<bool>(type: "bit", nullable: false),
                    ChangeInvoiceAfterReceive = table.Column<bool>(type: "bit", nullable: false),
                    ChangePatientRecordStatus = table.Column<bool>(type: "bit", nullable: false),
                    ContactCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ContactDelete = table.Column<bool>(type: "bit", nullable: false),
                    ContactView = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    DiscountReport = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseDelete = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseReport = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseView = table.Column<bool>(type: "bit", nullable: false),
                    FirstEncounterReport = table.Column<bool>(type: "bit", nullable: false),
                    GeneralSettingCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    GeneralSettingView = table.Column<bool>(type: "bit", nullable: false),
                    HolidayCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    HolidayDelete = table.Column<bool>(type: "bit", nullable: false),
                    HolidayView = table.Column<bool>(type: "bit", nullable: false),
                    InInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceCancel = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDelete = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDiscount = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceItemChangeReport = table.Column<bool>(type: "bit", nullable: true),
                    InvoiceView = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryDelete = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryView = table.Column<bool>(type: "bit", nullable: false),
                    JobCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    JobDelete = table.Column<bool>(type: "bit", nullable: false),
                    JobView = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    LetterDelete = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateDelete = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateView = table.Column<bool>(type: "bit", nullable: false),
                    LetterView = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAlertCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAlertDelete = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAlertUpdate = table.Column<bool>(type: "bit", nullable: true),
                    MedicalRecordSend = table.Column<bool>(type: "bit", nullable: false),
                    MedicalRecordView = table.Column<bool>(type: "bit", nullable: false),
                    MergePatients = table.Column<bool>(type: "bit", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotArraivedPatientsReport = table.Column<bool>(type: "bit", nullable: false),
                    OutInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionDelete = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionView = table.Column<bool>(type: "bit", nullable: false),
                    PatientCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PatientDelete = table.Column<bool>(type: "bit", nullable: false),
                    PatientFieldCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PatientFieldView = table.Column<bool>(type: "bit", nullable: false),
                    PatientView = table.Column<bool>(type: "bit", nullable: false),
                    PaymentAllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    PaymentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDelete = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReport = table.Column<bool>(type: "bit", nullable: false),
                    PaymentView = table.Column<bool>(type: "bit", nullable: false),
                    PractitionerReport = table.Column<bool>(type: "bit", nullable: false),
                    ProductCardexCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ProductCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ProductDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductView = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptAllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptDelete = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptPaymentReport = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptReport = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptView = table.Column<bool>(type: "bit", nullable: false),
                    Report = table.Column<bool>(type: "bit", nullable: false),
                    RoleCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    RoleDelete = table.Column<bool>(type: "bit", nullable: false),
                    RoleView = table.Column<bool>(type: "bit", nullable: false),
                    SMSSettingCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    SMSSettingView = table.Column<bool>(type: "bit", nullable: false),
                    SetAppointmentPermission = table.Column<bool>(type: "bit", nullable: false),
                    Setting = table.Column<bool>(type: "bit", nullable: false),
                    SummaryReport = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionDelete = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionView = table.Column<bool>(type: "bit", nullable: false),
                    TotdayAppointmentView = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateDelete = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateView = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentView = table.Column<bool>(type: "bit", nullable: false),
                    UnChangeInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    UserCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    UserDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserView = table.Column<bool>(type: "bit", nullable: false),
                    VisitReport = table.Column<bool>(type: "bit", nullable: true),
                    WatingReport = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesCtx", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
