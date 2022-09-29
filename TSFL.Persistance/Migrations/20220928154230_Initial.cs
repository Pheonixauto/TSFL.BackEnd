using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TSFL.Persistance.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardGroupCards",
                columns: table => new
                {
                    CardGroupCards_CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardGroupCards_GroupCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGroupCards", x => new { x.CardGroupCards_CardId, x.CardGroupCards_GroupCardId });
                    table.ForeignKey(
                        name: "FK_CardGroupCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CardGroupCards_GroupCards_GroupCardId",
                        column: x => x.GroupCardId,
                        principalTable: "GroupCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupCard_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_GroupCards_GroupCard_Id",
                        column: x => x.GroupCard_Id,
                        principalTable: "GroupCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupCards_CardId",
                table: "CardGroupCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardGroupCards_GroupCardId",
                table: "CardGroupCards",
                column: "GroupCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_GroupCard_Id",
                table: "Members",
                column: "GroupCard_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardGroupCards");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "GroupCards");
        }
    }
}
