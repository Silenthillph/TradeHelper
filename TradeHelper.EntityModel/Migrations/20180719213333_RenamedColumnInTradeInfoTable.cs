using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TradeHelper.EntityModel.Migrations
{
    public partial class RenamedColumnInTradeInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CellPrice",
                table: "TradeInfo",
                newName: "SellPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "TradeInfo",
                newName: "CellPrice");
        }
    }
}
