using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class RenamedExpirationn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenExpires",
                table: "RefreshToken",
                newName: "TokenExpiry");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpires",
                table: "RefreshToken",
                newName: "RefreshTokenExpiry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenExpiry",
                table: "RefreshToken",
                newName: "TokenExpires");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpiry",
                table: "RefreshToken",
                newName: "RefreshTokenExpires");
        }
    }
}
