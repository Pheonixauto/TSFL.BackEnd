using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinWin.Api.Migrations
{
    public partial class addcolumn_Card : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathContent",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathImage",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathContent",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PathImage",
                table: "Cards");
        }
    }
}
