using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineSchool.Migrations
{
    public partial class DatabaseFile5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Authorizations_AuthID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Authorizations_AuthID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Authorizations_AuthID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_AuthID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_AuthID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Admin_AuthID",
                table: "Admin");

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Tutorial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Teacher_Tutorial_Like",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Teacher_Tutorial_Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Teacher_Course_Tutorial",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Student_Tutorial_Like",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Student_Tutorial_Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Like",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Admin_Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Tutorial");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Teacher_Tutorial_Like");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Teacher_Tutorial_Comment");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Teacher_Course_Tutorial");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Student_Tutorial_Like");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Student_Tutorial_Comment");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Admin_Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AuthID",
                table: "Teacher",
                column: "AuthID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AuthID",
                table: "Student",
                column: "AuthID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AuthID",
                table: "Admin",
                column: "AuthID");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Authorizations_AuthID",
                table: "Admin",
                column: "AuthID",
                principalTable: "Authorizations",
                principalColumn: "AuthID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Authorizations_AuthID",
                table: "Student",
                column: "AuthID",
                principalTable: "Authorizations",
                principalColumn: "AuthID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Authorizations_AuthID",
                table: "Teacher",
                column: "AuthID",
                principalTable: "Authorizations",
                principalColumn: "AuthID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
