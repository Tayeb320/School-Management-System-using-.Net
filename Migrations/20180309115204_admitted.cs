using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolWeb.Migrations
{
    public partial class admitted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admitted",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    Contact = table.Column<long>(nullable: false),
                    FatherName = table.Column<string>(nullable: false),
                    Guardian = table.Column<string>(nullable: true),
                    GuardianDetails = table.Column<string>(nullable: false),
                    LastSchool = table.Column<string>(nullable: false),
                    MotherName = table.Column<string>(nullable: false),
                    PerPost = table.Column<string>(nullable: false),
                    PerVill = table.Column<string>(nullable: false),
                    PerZila = table.Column<string>(nullable: false),
                    PrePost = table.Column<string>(nullable: false),
                    PreVill = table.Column<string>(nullable: false),
                    PreZila = table.Column<string>(nullable: false),
                    Religion = table.Column<string>(nullable: false),
                    StudentNameBan = table.Column<string>(nullable: false),
                    StudentNameEng = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admitted", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admitted");
        }
    }
}
