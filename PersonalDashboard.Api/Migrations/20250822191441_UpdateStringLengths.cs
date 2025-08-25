using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDashBoard.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStringLengths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_agent",
                table: "login_attempts",
                type: "TEXT",
                maxLength: 512,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_agent",
                table: "login_attempts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 512);
        }
    }
}
