using Microsoft.EntityFrameworkCore.Migrations;

namespace CRYBZ_CCSB.Migrations
{
    public partial class Ronanisdom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountEdit",
                table: "AccountEdit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AccountEdit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AccountID",
                table: "AccountEdit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountEdit",
                table: "AccountEdit",
                column: "AccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountEdit",
                table: "AccountEdit");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "AccountEdit");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AccountEdit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountEdit",
                table: "AccountEdit",
                column: "FirstName");
        }
    }
}
