using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolWeb.Migrations
{
    public partial class mark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agriculture = table.Column<int>(nullable: true),
                    Bangla = table.Column<int>(nullable: true),
                    Bangla2ndPaper = table.Column<int>(nullable: true),
                    Biology = table.Column<int>(nullable: true),
                    Camistry = table.Column<int>(nullable: true),
                    English = table.Column<int>(nullable: true),
                    English2ndPaper = table.Column<int>(nullable: true),
                    HigherMath = table.Column<int>(nullable: true),
                    Ict = table.Column<int>(nullable: true),
                    Math = table.Column<int>(nullable: true),
                    RollNumber = table.Column<int>(nullable: false),
                    Science = table.Column<int>(nullable: true),
                    SocialScience = table.Column<int>(nullable: true),
                    StudentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");
        }
    }
}
