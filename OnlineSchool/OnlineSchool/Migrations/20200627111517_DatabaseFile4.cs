using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineSchool.Migrations
{
    public partial class DatabaseFile4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Authorization_AuthID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Authorization_AuthID",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorization",
                table: "Authorization");

            migrationBuilder.RenameTable(
                name: "Authorization",
                newName: "Authorizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "AuthID");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ADID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Profile_Image_Path = table.Column<string>(maxLength: 1000, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    AuthID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ADID);
                    table.ForeignKey(
                        name: "FK_Admin_Authorizations_AuthID",
                        column: x => x.AuthID,
                        principalTable: "Authorizations",
                        principalColumn: "AuthID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin_Courses",
                columns: table => new
                {
                    AC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADID = table.Column<int>(nullable: false),
                    CID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin_Courses", x => x.AC);
                    table.ForeignKey(
                        name: "FK_Admin_Courses_Admin_ADID",
                        column: x => x.ADID,
                        principalTable: "Admin",
                        principalColumn: "ADID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Courses_Course_CID",
                        column: x => x.CID,
                        principalTable: "Course",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AuthID",
                table: "Admin",
                column: "AuthID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Courses_ADID",
                table: "Admin_Courses",
                column: "ADID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Courses_CID",
                table: "Admin_Courses",
                column: "CID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Authorizations_AuthID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Authorizations_AuthID",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Admin_Courses");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameTable(
                name: "Authorizations",
                newName: "Authorization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorization",
                table: "Authorization",
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
    }
}
