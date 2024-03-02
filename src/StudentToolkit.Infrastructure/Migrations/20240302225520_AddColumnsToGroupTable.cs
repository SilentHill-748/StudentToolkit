using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentToolkit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "group_code",
                table: "groups",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<int>(
                name: "admission_year",
                table: "groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "education_format",
                table: "groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "education_type",
                table: "groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "group_name",
                table: "groups",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "admission_year",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "education_format",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "education_type",
                table: "groups");

            migrationBuilder.DropColumn(
                name: "group_name",
                table: "groups");

            migrationBuilder.AlterColumn<string>(
                name: "group_code",
                table: "groups",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
