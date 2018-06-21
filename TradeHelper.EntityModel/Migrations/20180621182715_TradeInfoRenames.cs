using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TradeHelper.EntityModel.Migrations
{
    public partial class TradeInfoRenames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "TradeInfo",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "TradeInfo",
                newName: "PositionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TradeInfo",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "PositionType",
                table: "TradeInfo",
                newName: "PositionId");
        }
    }
}
