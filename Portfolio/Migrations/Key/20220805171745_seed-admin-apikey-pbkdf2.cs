using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations.Key
{
    public partial class seedadminapikeypbkdf2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Keys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "iD2e/0oQtUFkAz4omzjZ8g==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Keys",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: "$2a$11$VoUfhnw5RfQhMCJBXSMFw.ug8Is12oOwup2tiZfjUDLclAq/XwVVy");
        }
    }
}
