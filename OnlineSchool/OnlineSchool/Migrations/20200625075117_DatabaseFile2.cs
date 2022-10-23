using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineSchool.Migrations
{
    public partial class DatabaseFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_comment_comment_ComID",
                table: "student_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_comment_student_SID",
                table: "student_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_comment_tutorial_TID",
                table: "student_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_like_like_LID",
                table: "student_tutorial_like");

            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_like_student_SID",
                table: "student_tutorial_like");

            migrationBuilder.DropForeignKey(
                name: "FK_student_tutorial_like_tutorial_TID",
                table: "student_tutorial_like");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_comment_comment_ComID",
                table: "teacher_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_comment_tutorial_TID",
                table: "teacher_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_comment_teacher_TeID",
                table: "teacher_tutorial_comment");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_like_like_LID",
                table: "teacher_tutorial_like");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_like_tutorial_TID",
                table: "teacher_tutorial_like");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_tutorial_like_teacher_TeID",
                table: "teacher_tutorial_like");

            migrationBuilder.DropTable(
                name: "teacher_cetagory_tutorial");

            migrationBuilder.DropTable(
                name: "cetagory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tutorial",
                table: "tutorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacher_tutorial_like",
                table: "teacher_tutorial_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacher_tutorial_comment",
                table: "teacher_tutorial_comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacher",
                table: "teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student_tutorial_like",
                table: "student_tutorial_like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student_tutorial_comment",
                table: "student_tutorial_comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_like",
                table: "like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comment",
                table: "comment");

            migrationBuilder.RenameTable(
                name: "tutorial",
                newName: "Tutorial");

            migrationBuilder.RenameTable(
                name: "teacher_tutorial_like",
                newName: "Teacher_Tutorial_Like");

            migrationBuilder.RenameTable(
                name: "teacher_tutorial_comment",
                newName: "Teacher_Tutorial_Comment");

            migrationBuilder.RenameTable(
                name: "teacher",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "student_tutorial_like",
                newName: "Student_Tutorial_Like");

            migrationBuilder.RenameTable(
                name: "student_tutorial_comment",
                newName: "Student_Tutorial_Comment");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "like",
                newName: "Like");

            migrationBuilder.RenameTable(
                name: "comment",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_like_TeID",
                table: "Teacher_Tutorial_Like",
                newName: "IX_Teacher_Tutorial_Like_TeID");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_like_TID",
                table: "Teacher_Tutorial_Like",
                newName: "IX_Teacher_Tutorial_Like_TID");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_like_LID",
                table: "Teacher_Tutorial_Like",
                newName: "IX_Teacher_Tutorial_Like_LID");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_comment_TeID",
                table: "Teacher_Tutorial_Comment",
                newName: "IX_Teacher_Tutorial_Comment_TeID");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_comment_TID",
                table: "Teacher_Tutorial_Comment",
                newName: "IX_Teacher_Tutorial_Comment_TID");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_tutorial_comment_ComID",
                table: "Teacher_Tutorial_Comment",
                newName: "IX_Teacher_Tutorial_Comment_ComID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_like_TID",
                table: "Student_Tutorial_Like",
                newName: "IX_Student_Tutorial_Like_TID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_like_SID",
                table: "Student_Tutorial_Like",
                newName: "IX_Student_Tutorial_Like_SID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_like_LID",
                table: "Student_Tutorial_Like",
                newName: "IX_Student_Tutorial_Like_LID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_comment_TID",
                table: "Student_Tutorial_Comment",
                newName: "IX_Student_Tutorial_Comment_TID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_comment_SID",
                table: "Student_Tutorial_Comment",
                newName: "IX_Student_Tutorial_Comment_SID");

            migrationBuilder.RenameIndex(
                name: "IX_student_tutorial_comment_ComID",
                table: "Student_Tutorial_Comment",
                newName: "IX_Student_Tutorial_Comment_ComID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tutorial",
                table: "Tutorial",
                column: "TID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Tutorial_Like",
                table: "Teacher_Tutorial_Like",
                column: "TeTL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher_Tutorial_Comment",
                table: "Teacher_Tutorial_Comment",
                column: "TTC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "TeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Tutorial_Like",
                table: "Student_Tutorial_Like",
                column: "STL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Tutorial_Comment",
                table: "Student_Tutorial_Comment",
                column: "STC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "SID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "LID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "ComID");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image_Path = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_Course_Tutorial",
                columns: table => new
                {
                    TeCT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeID = table.Column<int>(nullable: false),
                    CID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_Course_Tutorial", x => x.TeCT);
                    table.ForeignKey(
                        name: "FK_Teacher_Course_Tutorial_Course_CID",
                        column: x => x.CID,
                        principalTable: "Course",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Course_Tutorial_Tutorial_TID",
                        column: x => x.TID,
                        principalTable: "Tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_Course_Tutorial_Teacher_TeID",
                        column: x => x.TeID,
                        principalTable: "Teacher",
                        principalColumn: "TeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Course_Tutorial_CID",
                table: "Teacher_Course_Tutorial",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Course_Tutorial_TID",
                table: "Teacher_Course_Tutorial",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Course_Tutorial_TeID",
                table: "Teacher_Course_Tutorial",
                column: "TeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Comment_Comment_ComID",
                table: "Student_Tutorial_Comment",
                column: "ComID",
                principalTable: "Comment",
                principalColumn: "ComID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Comment_Student_SID",
                table: "Student_Tutorial_Comment",
                column: "SID",
                principalTable: "Student",
                principalColumn: "SID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Comment_Tutorial_TID",
                table: "Student_Tutorial_Comment",
                column: "TID",
                principalTable: "Tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Like_Like_LID",
                table: "Student_Tutorial_Like",
                column: "LID",
                principalTable: "Like",
                principalColumn: "LID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Like_Student_SID",
                table: "Student_Tutorial_Like",
                column: "SID",
                principalTable: "Student",
                principalColumn: "SID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Tutorial_Like_Tutorial_TID",
                table: "Student_Tutorial_Like",
                column: "TID",
                principalTable: "Tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Comment_ComID",
                table: "Teacher_Tutorial_Comment",
                column: "ComID",
                principalTable: "Comment",
                principalColumn: "ComID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Tutorial_TID",
                table: "Teacher_Tutorial_Comment",
                column: "TID",
                principalTable: "Tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Teacher_TeID",
                table: "Teacher_Tutorial_Comment",
                column: "TeID",
                principalTable: "Teacher",
                principalColumn: "TeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Like_Like_LID",
                table: "Teacher_Tutorial_Like",
                column: "LID",
                principalTable: "Like",
                principalColumn: "LID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Like_Tutorial_TID",
                table: "Teacher_Tutorial_Like",
                column: "TID",
                principalTable: "Tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Tutorial_Like_Teacher_TeID",
                table: "Teacher_Tutorial_Like",
                column: "TeID",
                principalTable: "Teacher",
                principalColumn: "TeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Comment_Comment_ComID",
                table: "Student_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Comment_Student_SID",
                table: "Student_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Comment_Tutorial_TID",
                table: "Student_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Like_Like_LID",
                table: "Student_Tutorial_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Like_Student_SID",
                table: "Student_Tutorial_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Tutorial_Like_Tutorial_TID",
                table: "Student_Tutorial_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Comment_ComID",
                table: "Teacher_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Tutorial_TID",
                table: "Teacher_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Comment_Teacher_TeID",
                table: "Teacher_Tutorial_Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Like_Like_LID",
                table: "Teacher_Tutorial_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Like_Tutorial_TID",
                table: "Teacher_Tutorial_Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Tutorial_Like_Teacher_TeID",
                table: "Teacher_Tutorial_Like");

            migrationBuilder.DropTable(
                name: "Teacher_Course_Tutorial");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tutorial",
                table: "Tutorial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Tutorial_Like",
                table: "Teacher_Tutorial_Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher_Tutorial_Comment",
                table: "Teacher_Tutorial_Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Tutorial_Like",
                table: "Student_Tutorial_Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Tutorial_Comment",
                table: "Student_Tutorial_Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Tutorial",
                newName: "tutorial");

            migrationBuilder.RenameTable(
                name: "Teacher_Tutorial_Like",
                newName: "teacher_tutorial_like");

            migrationBuilder.RenameTable(
                name: "Teacher_Tutorial_Comment",
                newName: "teacher_tutorial_comment");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "teacher");

            migrationBuilder.RenameTable(
                name: "Student_Tutorial_Like",
                newName: "student_tutorial_like");

            migrationBuilder.RenameTable(
                name: "Student_Tutorial_Comment",
                newName: "student_tutorial_comment");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "student");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "like");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "comment");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Like_TeID",
                table: "teacher_tutorial_like",
                newName: "IX_teacher_tutorial_like_TeID");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Like_TID",
                table: "teacher_tutorial_like",
                newName: "IX_teacher_tutorial_like_TID");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Like_LID",
                table: "teacher_tutorial_like",
                newName: "IX_teacher_tutorial_like_LID");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Comment_TeID",
                table: "teacher_tutorial_comment",
                newName: "IX_teacher_tutorial_comment_TeID");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Comment_TID",
                table: "teacher_tutorial_comment",
                newName: "IX_teacher_tutorial_comment_TID");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_Tutorial_Comment_ComID",
                table: "teacher_tutorial_comment",
                newName: "IX_teacher_tutorial_comment_ComID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Like_TID",
                table: "student_tutorial_like",
                newName: "IX_student_tutorial_like_TID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Like_SID",
                table: "student_tutorial_like",
                newName: "IX_student_tutorial_like_SID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Like_LID",
                table: "student_tutorial_like",
                newName: "IX_student_tutorial_like_LID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Comment_TID",
                table: "student_tutorial_comment",
                newName: "IX_student_tutorial_comment_TID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Comment_SID",
                table: "student_tutorial_comment",
                newName: "IX_student_tutorial_comment_SID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_Tutorial_Comment_ComID",
                table: "student_tutorial_comment",
                newName: "IX_student_tutorial_comment_ComID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tutorial",
                table: "tutorial",
                column: "TID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacher_tutorial_like",
                table: "teacher_tutorial_like",
                column: "TeTL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacher_tutorial_comment",
                table: "teacher_tutorial_comment",
                column: "TTC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacher",
                table: "teacher",
                column: "TeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student_tutorial_like",
                table: "student_tutorial_like",
                column: "STL");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student_tutorial_comment",
                table: "student_tutorial_comment",
                column: "STC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "SID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_like",
                table: "like",
                column: "LID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comment",
                table: "comment",
                column: "ComID");

            migrationBuilder.CreateTable(
                name: "cetagory",
                columns: table => new
                {
                    CID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image_Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cetagory", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "teacher_cetagory_tutorial",
                columns: table => new
                {
                    TeCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(type: "int", nullable: false),
                    TID = table.Column<int>(type: "int", nullable: false),
                    TeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_cetagory_tutorial", x => x.TeCT);
                    table.ForeignKey(
                        name: "FK_teacher_cetagory_tutorial_cetagory_CID",
                        column: x => x.CID,
                        principalTable: "cetagory",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_cetagory_tutorial_tutorial_TID",
                        column: x => x.TID,
                        principalTable: "tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_cetagory_tutorial_teacher_TeID",
                        column: x => x.TeID,
                        principalTable: "teacher",
                        principalColumn: "TeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teacher_cetagory_tutorial_CID",
                table: "teacher_cetagory_tutorial",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_cetagory_tutorial_TID",
                table: "teacher_cetagory_tutorial",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_cetagory_tutorial_TeID",
                table: "teacher_cetagory_tutorial",
                column: "TeID");

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_comment_comment_ComID",
                table: "student_tutorial_comment",
                column: "ComID",
                principalTable: "comment",
                principalColumn: "ComID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_comment_student_SID",
                table: "student_tutorial_comment",
                column: "SID",
                principalTable: "student",
                principalColumn: "SID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_comment_tutorial_TID",
                table: "student_tutorial_comment",
                column: "TID",
                principalTable: "tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_like_like_LID",
                table: "student_tutorial_like",
                column: "LID",
                principalTable: "like",
                principalColumn: "LID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_like_student_SID",
                table: "student_tutorial_like",
                column: "SID",
                principalTable: "student",
                principalColumn: "SID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_tutorial_like_tutorial_TID",
                table: "student_tutorial_like",
                column: "TID",
                principalTable: "tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_comment_comment_ComID",
                table: "teacher_tutorial_comment",
                column: "ComID",
                principalTable: "comment",
                principalColumn: "ComID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_comment_tutorial_TID",
                table: "teacher_tutorial_comment",
                column: "TID",
                principalTable: "tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_comment_teacher_TeID",
                table: "teacher_tutorial_comment",
                column: "TeID",
                principalTable: "teacher",
                principalColumn: "TeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_like_like_LID",
                table: "teacher_tutorial_like",
                column: "LID",
                principalTable: "like",
                principalColumn: "LID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_like_tutorial_TID",
                table: "teacher_tutorial_like",
                column: "TID",
                principalTable: "tutorial",
                principalColumn: "TID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_tutorial_like_teacher_TeID",
                table: "teacher_tutorial_like",
                column: "TeID",
                principalTable: "teacher",
                principalColumn: "TeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
