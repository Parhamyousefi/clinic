using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Api.Migrations
{
    /// <inheritdoc />
    public partial class FirstTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesCtx",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralSettingView = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentView = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    PatientView = table.Column<bool>(type: "bit", nullable: false),
                    PatientCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PatientDelete = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceView = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDelete = table.Column<bool>(type: "bit", nullable: false),
                    PaymentView = table.Column<bool>(type: "bit", nullable: false),
                    PaymentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDelete = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseView = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductView = table.Column<bool>(type: "bit", nullable: false),
                    ProductCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ProductDelete = table.Column<bool>(type: "bit", nullable: false),
                    ContactView = table.Column<bool>(type: "bit", nullable: false),
                    ContactCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ContactDelete = table.Column<bool>(type: "bit", nullable: false),
                    BusinessView = table.Column<bool>(type: "bit", nullable: false),
                    BusinessCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    BusinessDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserView = table.Column<bool>(type: "bit", nullable: false),
                    UserCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    UserDelete = table.Column<bool>(type: "bit", nullable: false),
                    RoleView = table.Column<bool>(type: "bit", nullable: false),
                    RoleCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    RoleDelete = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeView = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AppointmentTypeDelete = table.Column<bool>(type: "bit", nullable: false),
                    HolidayView = table.Column<bool>(type: "bit", nullable: false),
                    HolidayCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    HolidayDelete = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionView = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TimeExceptionDelete = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemView = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    BillableItemDelete = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateView = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateDelete = table.Column<bool>(type: "bit", nullable: false),
                    SummaryReport = table.Column<bool>(type: "bit", nullable: false),
                    PaymentReport = table.Column<bool>(type: "bit", nullable: false),
                    ExpenseReport = table.Column<bool>(type: "bit", nullable: false),
                    Report = table.Column<bool>(type: "bit", nullable: false),
                    Setting = table.Column<bool>(type: "bit", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AllowPayLater = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateView = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    LetterTemplateDelete = table.Column<bool>(type: "bit", nullable: false),
                    LetterView = table.Column<bool>(type: "bit", nullable: false),
                    LetterCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    LetterDelete = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentView = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentView = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    AttachmentDelete = table.Column<bool>(type: "bit", nullable: false),
                    SMSSettingView = table.Column<bool>(type: "bit", nullable: false),
                    SMSSettingCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    GeneralSettingCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ProductCardexCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptView = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptDelete = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptReport = table.Column<bool>(type: "bit", nullable: false),
                    TotdayAppointmentView = table.Column<bool>(type: "bit", nullable: false),
                    ChangeInvoiceAfterReceive = table.Column<bool>(type: "bit", nullable: false),
                    DiscountReport = table.Column<bool>(type: "bit", nullable: false),
                    NotArraivedPatientsReport = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceCancel = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptAllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDiscount = table.Column<bool>(type: "bit", nullable: false),
                    PaymentAllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordView = table.Column<bool>(type: "bit", nullable: false),
                    MedicalRecordSend = table.Column<bool>(type: "bit", nullable: false),
                    PatientFieldView = table.Column<bool>(type: "bit", nullable: false),
                    PatientFieldCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    JobView = table.Column<bool>(type: "bit", nullable: false),
                    JobCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    JobDelete = table.Column<bool>(type: "bit", nullable: false),
                    OutInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    InInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionView = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    OutOfTurnExceptionDelete = table.Column<bool>(type: "bit", nullable: false),
                    UnChangeInvoiceReport = table.Column<bool>(type: "bit", nullable: false),
                    SetAppointmentPermission = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryView = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    ItemCategoryDelete = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptPaymentReport = table.Column<bool>(type: "bit", nullable: false),
                    AllowReceiptOverBalance = table.Column<bool>(type: "bit", nullable: false),
                    AllowPayOverBalance = table.Column<bool>(type: "bit", nullable: false),
                    AcceptDiscount = table.Column<bool>(type: "bit", nullable: false),
                    CashierByCashAndETFPosReport = table.Column<bool>(type: "bit", nullable: false),
                    PractitionerReport = table.Column<bool>(type: "bit", nullable: false),
                    WatingReport = table.Column<bool>(type: "bit", nullable: false),
                    FirstEncounterReport = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAlertCreateAndUpdate = table.Column<bool>(type: "bit", nullable: false),
                    MedicalAlertDelete = table.Column<bool>(type: "bit", nullable: false),
                    ChangePatientRecordStatus = table.Column<bool>(type: "bit", nullable: false),
                    CanAcceptItem = table.Column<bool>(type: "bit", nullable: false),
                    VisitReport = table.Column<bool>(type: "bit", nullable: true),
                    InvoiceItemChangeReport = table.Column<bool>(type: "bit", nullable: true),
                    MedicalAlertUpdate = table.Column<bool>(type: "bit", nullable: true),
                    MergePatients = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesCtx", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeExceptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    TimeExceptionTypeId = table.Column<int>(type: "int", nullable: false),
                    RepeatId = table.Column<int>(type: "int", nullable: true),
                    RepeatEvery = table.Column<int>(type: "int", nullable: true),
                    EndsAfter = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    GrigoryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    PractitionerTimeExceptionId = table.Column<int>(type: "int", nullable: true),
                    OutOfTurn = table.Column<int>(type: "int", nullable: false),
                    DefaultAppointmentTypeId = table.Column<int>(type: "int", nullable: true),
                    TimeSlotSize = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeExceptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    IsFinal = table.Column<bool>(type: "bit", nullable: false),
                    TreatmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    InvoiceItemId = table.Column<int>(type: "int", nullable: true),
                    VisitTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    OutOfTurn = table.Column<int>(type: "int", nullable: true),
                    DefaultAppointmentTypeId = table.Column<int>(type: "int", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSlotSize = table.Column<int>(type: "int", nullable: true),
                    CalendarTimeFrom = table.Column<int>(type: "int", nullable: true),
                    CalendarTimeTo = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true),
                    NewPatientAppointmentTypeId = table.Column<int>(type: "int", nullable: true),
                    MultipleAppointment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBusinesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PhoneNoTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaitListBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitList_Id = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitListBusinesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaitListPractitioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitList_Id = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitListPractitioners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaitLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableOnSat = table.Column<bool>(type: "bit", nullable: false),
                    AvailableOnSun = table.Column<bool>(type: "bit", nullable: false),
                    AvailableOnMon = table.Column<bool>(type: "bit", nullable: false),
                    AvailableOnTue = table.Column<bool>(type: "bit", nullable: false),
                    AvailableOnWed = table.Column<bool>(type: "bit", nullable: false),
                    AvailableOnThr = table.Column<bool>(type: "bit", nullable: false),
                    Urgent = table.Column<bool>(type: "bit", nullable: false),
                    OnlyOutsideBussinessHours = table.Column<bool>(type: "bit", nullable: false),
                    ExtraInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Removed = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ModifierId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPractitioner = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CancelNotificationTypeId = table.Column<int>(type: "int", nullable: true),
                    ShowInOnlineBookings = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowTreatmentOnClickPatientName = table.Column<bool>(type: "bit", nullable: false),
                    ForgetKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForgetDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DefaultTreatmentTemplateId = table.Column<int>(type: "int", nullable: true),
                    LoadLastDataOnNewTreatment = table.Column<bool>(type: "bit", nullable: false),
                    SuspendReservationDays = table.Column<int>(type: "int", nullable: false),
                    SMSEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CanChangeOldTreatment = table.Column<bool>(type: "bit", nullable: false),
                    CanConfirmInvoice = table.Column<bool>(type: "bit", nullable: false),
                    OutOfRange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolesCtx");

            migrationBuilder.DropTable(
                name: "TimeExceptions");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "UserAppointment");

            migrationBuilder.DropTable(
                name: "UserBusinesses");

            migrationBuilder.DropTable(
                name: "UserPhones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaitListBusinesses");

            migrationBuilder.DropTable(
                name: "WaitListPractitioners");

            migrationBuilder.DropTable(
                name: "WaitLists");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
