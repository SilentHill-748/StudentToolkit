using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentToolkit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTeachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subjects_teachers_teacher_id",
                table: "subjects");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_subjects_teacher_id",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "teacher_id",
                table: "subjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "teacher_id",
                table: "subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    teacher_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.teacher_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subjects_teacher_id",
                table: "subjects",
                column: "teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_subjects_teachers_teacher_id",
                table: "subjects",
                column: "teacher_id",
                principalTable: "teachers",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
