using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    public partial class fixcertificate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Certificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates",
                column: "TypeId",
                principalTable: "CertificateTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates",
                column: "TypeId",
                principalTable: "CertificateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
