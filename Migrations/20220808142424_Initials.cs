using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPension.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AadhaarNumber = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pensioner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PensionerName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    PAN = table.Column<string>(nullable: true),
                    SalaryEarned = table.Column<float>(nullable: false),
                    Allowances = table.Column<int>(nullable: false),
                    PensionType = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<long>(nullable: false),
                    BankType = table.Column<string>(nullable: true),
                    PensionAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pensioner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pensioner_Login_Id",
                        column: x => x.Id,
                        principalTable: "Login",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pensioner");

            migrationBuilder.DropTable(
                name: "Login");
        }
    }
}
