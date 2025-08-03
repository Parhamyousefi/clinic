using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Api.Migrations
{
    /// <inheritdoc />
    public partial class SecondTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    defaultClose = table.Column<bool>(type: "bit", nullable: false),
                    order = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    horizontalDirection = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMSSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendAfterAppointment = table.Column<bool>(type: "bit", nullable: false),
                    SendBeforeAppointmentDay = table.Column<bool>(type: "bit", nullable: false),
                    SendAfterAppointmentTemplateId = table.Column<int>(type: "int", nullable: false),
                    SendBeforeAppointmentDayTemplateId = table.Column<int>(type: "int", nullable: false),
                    ReminderDaysBefore = table.Column<int>(type: "int", nullable: false),
                    SendAfterAppointmentTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendBeforeAppointmentDayTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMSSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOutput = table.Column<bool>(type: "bit", nullable: false),
                    UseOnAdjust = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeExceptionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeExceptionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "SMSSettings");

            migrationBuilder.DropTable(
                name: "StockAdjustmentTypes");

            migrationBuilder.DropTable(
                name: "TimeExceptionTypes");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
