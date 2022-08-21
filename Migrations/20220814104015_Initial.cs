using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPension.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pensioner_Login_Id",
                table: "Pensioner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pensioner",
                table: "Pensioner");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pensioner");

            migrationBuilder.AddColumn<int>(
                name: "PensionerId",
                table: "Pensioner",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AadhaarNumber",
                table: "Pensioner",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pensioner",
                table: "Pensioner",
                column: "PensionerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pensioner",
                table: "Pensioner");

            migrationBuilder.DropColumn(
                name: "PensionerId",
                table: "Pensioner");

            migrationBuilder.DropColumn(
                name: "AadhaarNumber",
                table: "Pensioner");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Pensioner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pensioner",
                table: "Pensioner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pensioner_Login_Id",
                table: "Pensioner",
                column: "Id",
                principalTable: "Login",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
