using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPension.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankCharge",
                table: "Pensioner",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankCharge",
                table: "Pensioner");
        }
    }
}
