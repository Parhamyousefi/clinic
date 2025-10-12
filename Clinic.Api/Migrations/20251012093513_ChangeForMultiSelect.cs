using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForMultiSelect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalArts",
                table: "MedicalArts");

            migrationBuilder.RenameTable(
                name: "MedicalArts",
                newName: "MedicalAlerts");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerId",
                table: "QuestionValues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalAlerts",
                table: "MedicalAlerts",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalAlerts",
                table: "MedicalAlerts");

            migrationBuilder.RenameTable(
                name: "MedicalAlerts",
                newName: "MedicalArts");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "QuestionValues",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalArts",
                table: "MedicalArts",
                column: "Id");
        }
    }
}
