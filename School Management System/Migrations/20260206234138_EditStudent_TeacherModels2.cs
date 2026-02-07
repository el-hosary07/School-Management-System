using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class EditStudent_TeacherModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "Teachers",
                newName: "ConfirmPassword");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "Students",
                newName: "ConfirmPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Teachers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Students",
                newName: "EmailConfirmed");
        }
    }
}
