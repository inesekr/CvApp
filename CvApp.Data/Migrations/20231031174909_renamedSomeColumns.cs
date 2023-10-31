using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    public partial class renamedSomeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudyActualState",
                table: "Education",
                newName: "StudyStatus");

            migrationBuilder.RenameColumn(
                name: "EducationGrade",
                table: "Education",
                newName: "Degree");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudyStatus",
                table: "Education",
                newName: "StudyActualState");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Education",
                newName: "EducationGrade");
        }
    }
}
