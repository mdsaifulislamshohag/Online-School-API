using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineSchool.Migrations
{
    public partial class DatabaseFile3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Teacher",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Image_Path",
                table: "Teacher",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthID",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Image_Path",
                table: "Student",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Authorization",
                columns: table => new
                {
                    AuthID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Company_Name = table.Column<string>(maxLength: 500, nullable: true),
                    JWT_Token = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorization", x => x.AuthID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_AuthID",
                table: "Teacher",
                column: "AuthID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AuthID",
                table: "Student",
                column: "AuthID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Authorization_AuthID",
                table: "Student",
                column: "AuthID",
                principalTable: "Authorization",
                principalColumn: "AuthID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Authorization_AuthID",
                table: "Teacher",
                column: "AuthID",
                principalTable: "Authorization",
                principalColumn: "AuthID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Authorization_AuthID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Authorization_AuthID",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Authorization");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_AuthID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_AuthID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Profile_Image_Path",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "AuthID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Profile_Image_Path",
                table: "Student");
        }
    }
}
