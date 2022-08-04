using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    public partial class updatecertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualification_Resumes_ResumeId",
                table: "Qualification");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationDescription_Qualification_QualificationId",
                table: "QualificationDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationDescription",
                table: "QualificationDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification");

            migrationBuilder.RenameTable(
                name: "QualificationDescription",
                newName: "QualificationsDescriptions");

            migrationBuilder.RenameTable(
                name: "Qualification",
                newName: "Qualifications");

            migrationBuilder.RenameColumn(
                name: "IssuerId",
                table: "Certificates",
                newName: "Issuer");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationDescription_QualificationId",
                table: "QualificationsDescriptions",
                newName: "IX_QualificationsDescriptions_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Qualification_ResumeId",
                table: "Qualifications",
                newName: "IX_Qualifications_ResumeId");

            migrationBuilder.AlterColumn<string>(
                name: "Instructor",
                table: "Certificates",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationsDescriptions",
                table: "QualificationsDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates",
                column: "TypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates",
                column: "TypeId",
                principalTable: "CertificateTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_Resumes_ResumeId",
                table: "Qualifications",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationsDescriptions_Qualifications_QualificationId",
                table: "QualificationsDescriptions",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificateTypes_TypeId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_Resumes_ResumeId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_QualificationsDescriptions_Qualifications_QualificationId",
                table: "QualificationsDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_TypeId",
                table: "Certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationsDescriptions",
                table: "QualificationsDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Qualifications",
                table: "Qualifications");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Certificates");

            migrationBuilder.RenameTable(
                name: "QualificationsDescriptions",
                newName: "QualificationDescription");

            migrationBuilder.RenameTable(
                name: "Qualifications",
                newName: "Qualification");

            migrationBuilder.RenameColumn(
                name: "Issuer",
                table: "Certificates",
                newName: "IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_QualificationsDescriptions_QualificationId",
                table: "QualificationDescription",
                newName: "IX_QualificationDescription_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Qualifications_ResumeId",
                table: "Qualification",
                newName: "IX_Qualification_ResumeId");

            migrationBuilder.AlterColumn<string>(
                name: "Instructor",
                table: "Certificates",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationDescription",
                table: "QualificationDescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Qualification",
                table: "Qualification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualification_Resumes_ResumeId",
                table: "Qualification",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QualificationDescription_Qualification_QualificationId",
                table: "QualificationDescription",
                column: "QualificationId",
                principalTable: "Qualification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
