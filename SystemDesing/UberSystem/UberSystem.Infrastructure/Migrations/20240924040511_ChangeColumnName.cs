using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UberSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailVerified",
                table: "users",
                newName: "emailVerified");

            migrationBuilder.RenameColumn(
                name: "EmailVerificationToken",
                table: "users",
                newName: "emailVerifiedToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "emailVerified",
                table: "users",
                newName: "EmailVerified");

            migrationBuilder.RenameColumn(
                name: "emailVerifiedToken",
                table: "users",
                newName: "EmailVerificationToken");
        }
    }
}
