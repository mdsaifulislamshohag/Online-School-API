using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineSchool.Migrations
{
    public partial class DatabaseFile1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cetagory",
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
                    table.PrimaryKey("PK_cetagory", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    ComID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.ComID);
                });

            migrationBuilder.CreateTable(
                name: "like",
                columns: table => new
                {
                    LID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Likes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like", x => x.LID);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    SID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.SID);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    TeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Phone = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true),
                    CV_Path = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.TeID);
                });

            migrationBuilder.CreateTable(
                name: "tutorial",
                columns: table => new
                {
                    TID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Video_Path = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutorial", x => x.TID);
                });

            migrationBuilder.CreateTable(
                name: "student_tutorial_comment",
                columns: table => new
                {
                    STC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false),
                    ComID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_tutorial_comment", x => x.STC);
                    table.ForeignKey(
                        name: "FK_student_tutorial_comment_comment_ComID",
                        column: x => x.ComID,
                        principalTable: "comment",
                        principalColumn: "ComID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_tutorial_comment_student_SID",
                        column: x => x.SID,
                        principalTable: "student",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_tutorial_comment_tutorial_TID",
                        column: x => x.TID,
                        principalTable: "tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_tutorial_like",
                columns: table => new
                {
                    STL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false),
                    LID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_tutorial_like", x => x.STL);
                    table.ForeignKey(
                        name: "FK_student_tutorial_like_like_LID",
                        column: x => x.LID,
                        principalTable: "like",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_tutorial_like_student_SID",
                        column: x => x.SID,
                        principalTable: "student",
                        principalColumn: "SID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_tutorial_like_tutorial_TID",
                        column: x => x.TID,
                        principalTable: "tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_cetagory_tutorial",
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

            migrationBuilder.CreateTable(
                name: "teacher_tutorial_comment",
                columns: table => new
                {
                    TTC = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false),
                    ComID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_tutorial_comment", x => x.TTC);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_comment_comment_ComID",
                        column: x => x.ComID,
                        principalTable: "comment",
                        principalColumn: "ComID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_comment_tutorial_TID",
                        column: x => x.TID,
                        principalTable: "tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_comment_teacher_TeID",
                        column: x => x.TeID,
                        principalTable: "teacher",
                        principalColumn: "TeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teacher_tutorial_like",
                columns: table => new
                {
                    TeTL = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeID = table.Column<int>(nullable: false),
                    TID = table.Column<int>(nullable: false),
                    LID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_tutorial_like", x => x.TeTL);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_like_like_LID",
                        column: x => x.LID,
                        principalTable: "like",
                        principalColumn: "LID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_like_tutorial_TID",
                        column: x => x.TID,
                        principalTable: "tutorial",
                        principalColumn: "TID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_tutorial_like_teacher_TeID",
                        column: x => x.TeID,
                        principalTable: "teacher",
                        principalColumn: "TeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_comment_ComID",
                table: "student_tutorial_comment",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_comment_SID",
                table: "student_tutorial_comment",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_comment_TID",
                table: "student_tutorial_comment",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_like_LID",
                table: "student_tutorial_like",
                column: "LID");

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_like_SID",
                table: "student_tutorial_like",
                column: "SID");

            migrationBuilder.CreateIndex(
                name: "IX_student_tutorial_like_TID",
                table: "student_tutorial_like",
                column: "TID");

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

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_comment_ComID",
                table: "teacher_tutorial_comment",
                column: "ComID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_comment_TID",
                table: "teacher_tutorial_comment",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_comment_TeID",
                table: "teacher_tutorial_comment",
                column: "TeID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_like_LID",
                table: "teacher_tutorial_like",
                column: "LID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_like_TID",
                table: "teacher_tutorial_like",
                column: "TID");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_tutorial_like_TeID",
                table: "teacher_tutorial_like",
                column: "TeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student_tutorial_comment");

            migrationBuilder.DropTable(
                name: "student_tutorial_like");

            migrationBuilder.DropTable(
                name: "teacher_cetagory_tutorial");

            migrationBuilder.DropTable(
                name: "teacher_tutorial_comment");

            migrationBuilder.DropTable(
                name: "teacher_tutorial_like");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "cetagory");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "like");

            migrationBuilder.DropTable(
                name: "tutorial");

            migrationBuilder.DropTable(
                name: "teacher");
        }
    }
}
