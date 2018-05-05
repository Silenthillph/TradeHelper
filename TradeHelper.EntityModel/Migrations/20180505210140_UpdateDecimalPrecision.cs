using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TradeHelper.EntityModel.Migrations
{
    public partial class UpdateDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TradeInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    CellPrice = table.Column<decimal>(type: "decimal(10, 4)", nullable: true),
                    CloseDate = table.Column<DateTime>(nullable: true),
                    PairCode = table.Column<string>(nullable: true),
                    PositionId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TradeInfo");
        }
    }
}
