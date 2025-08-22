using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDashBoard.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dashboard_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dashboard_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "login_attempts",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ip_address = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    is_successful = table.Column<bool>(type: "INTEGER", nullable: false),
                    attempted_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    user_agent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login_attempts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dashboard_users_email",
                table: "dashboard_users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dashboard_users_username",
                table: "dashboard_users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_login_attempts_attempted_at",
                table: "login_attempts",
                column: "attempted_at");

            migrationBuilder.CreateIndex(
                name: "IX_login_attempts_ip_address",
                table: "login_attempts",
                column: "ip_address");

            migrationBuilder.CreateIndex(
                name: "IX_login_attempts_username",
                table: "login_attempts",
                column: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dashboard_users");

            migrationBuilder.DropTable(
                name: "login_attempts");
        }
    }
}
