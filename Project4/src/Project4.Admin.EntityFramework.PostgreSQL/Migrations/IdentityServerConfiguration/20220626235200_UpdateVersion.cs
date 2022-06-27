using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project4.Admin.EntityFramework.PostgreSQL.Migrations.IdentityServerConfiguration
{
    public partial class UpdateVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients",
                type: "boolean",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinateLifetimeWithUserSession",
                table: "Clients");
        }
    }
}
