using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolWeb.Migrations
{
    public partial class TA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Actor_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Actor_Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Actor_Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contact = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(maxLength: 40, nullable: true),
                    Teacher_Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_Class_Id",
                table: "Result",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Result_ExamType_Id",
                table: "Result",
                column: "ExamType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Section_Id",
                table: "Result",
                column: "Section_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Result_Subject_Id",
                table: "Result",
                column: "Subject_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Class_Class_Id",
                table: "Result",
                column: "Class_Id",
                principalTable: "Class",
                principalColumn: "Class_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_ExamType_ExamType_Id",
                table: "Result",
                column: "ExamType_Id",
                principalTable: "ExamType",
                principalColumn: "ExamType_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Section_Section_Id",
                table: "Result",
                column: "Section_Id",
                principalTable: "Section",
                principalColumn: "Section_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Subject_Subject_Id",
                table: "Result",
                column: "Subject_Id",
                principalTable: "Subject",
                principalColumn: "Subject_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Class_Class_Id",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_ExamType_ExamType_Id",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Section_Section_Id",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Subject_Subject_Id",
                table: "Result");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Result_Class_Id",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_ExamType_Id",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_Section_Id",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_Subject_Id",
                table: "Result");
        }
    }
}
