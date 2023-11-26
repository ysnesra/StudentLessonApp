using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentLessonApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteLessonStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonStudent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LessonStudent",
                columns: table => new
                {
                    LessonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonStudent", x => new { x.LessonsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LessonStudent_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LessonStudent_StudentsId",
                table: "LessonStudent",
                column: "StudentsId");
        }
    }
}
