using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentToolkit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNameAtGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "group_name",
                table: "groups",
                newName: "education_direction");

            migrationBuilder.AlterColumn<string>(
                name: "group_code",
                table: "groups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "education_direction",
                table: "groups",
                newName: "group_name");

            migrationBuilder.AlterColumn<string>(
                name: "group_code",
                table: "groups",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
