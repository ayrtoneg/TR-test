using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OLC.Cases.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseNumber = table.Column<string>(type: "varchar(24)", nullable: false),
                    CourtName = table.Column<string>(type: "varchar(100)", nullable: false),
                    NameOfTheResponsible = table.Column<string>(type: "varchar(100)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
