using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelajarPostGre.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "public",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "public",
                newName: "Addresses",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                schema: "public",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                schema: "public",
                table: "Addresses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                schema: "public",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                schema: "public",
                newName: "Address",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                schema: "public",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "public",
                table: "Address",
                column: "Id");
        }
    }
}
