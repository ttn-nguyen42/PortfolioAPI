using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio.Migrations
{
    public partial class resumeentitychanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectType_TypeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Resumes_ResumeId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDescription_Project_ProjectId",
                table: "ProjectDescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLink_Project_ProjectId",
                table: "ProjectLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLink",
                table: "ProjectLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDescription",
                table: "ProjectDescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypes");

            migrationBuilder.RenameTable(
                name: "ProjectLink",
                newName: "ProjectLinks");

            migrationBuilder.RenameTable(
                name: "ProjectDescription",
                newName: "ProjectDescriptions");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLink_ProjectId",
                table: "ProjectLinks",
                newName: "IX_ProjectLinks_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDescription_ProjectId",
                table: "ProjectDescriptions",
                newName: "IX_ProjectDescriptions_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_TypeId",
                table: "Projects",
                newName: "IX_Projects_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ResumeId",
                table: "Projects",
                newName: "IX_Projects_ResumeId");

            migrationBuilder.AlterColumn<string>(
                name: "Overview",
                table: "Projects",
                type: "varchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLinks",
                table: "ProjectLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDescriptions",
                table: "ProjectDescriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDescriptions_Projects_ProjectId",
                table: "ProjectDescriptions",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_TypeId",
                table: "Projects",
                column: "TypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Resumes_ResumeId",
                table: "Projects",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDescriptions_Projects_ProjectId",
                table: "ProjectDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_TypeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Resumes_ResumeId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLinks",
                table: "ProjectLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectDescriptions",
                table: "ProjectDescriptions");

            migrationBuilder.RenameTable(
                name: "ProjectTypes",
                newName: "ProjectType");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "ProjectLinks",
                newName: "ProjectLink");

            migrationBuilder.RenameTable(
                name: "ProjectDescriptions",
                newName: "ProjectDescription");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_TypeId",
                table: "Project",
                newName: "IX_Project_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ResumeId",
                table: "Project",
                newName: "IX_Project_ResumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLinks_ProjectId",
                table: "ProjectLink",
                newName: "IX_ProjectLink_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectDescriptions_ProjectId",
                table: "ProjectDescription",
                newName: "IX_ProjectDescription_ProjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Overview",
                table: "Project",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(300)",
                oldMaxLength: 300)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLink",
                table: "ProjectLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectDescription",
                table: "ProjectDescription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectType_TypeId",
                table: "Project",
                column: "TypeId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Resumes_ResumeId",
                table: "Project",
                column: "ResumeId",
                principalTable: "Resumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDescription_Project_ProjectId",
                table: "ProjectDescription",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLink_Project_ProjectId",
                table: "ProjectLink",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
