using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    public partial class fixcertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTypes_Certificates_CertificateId",
                table: "CertificateTypes");

            migrationBuilder.DropIndex(
                name: "IX_CertificateTypes_CertificateId",
                table: "CertificateTypes");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "CertificateTypes");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates");

            migrationBuilder.AddColumn<int>(
                name: "CertificateId",
                table: "CertificateTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTypes_CertificateId",
                table: "CertificateTypes",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates",
                column: "TypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTypes_Certificates_CertificateId",
                table: "CertificateTypes",
                column: "CertificateId",
                principalTable: "Certificates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
