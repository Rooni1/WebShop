using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class Ordrarinlagda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "OrderDate" },
                values: new object[] { 1, new DateTime(2021, 10, 21, 10, 43, 13, 916, DateTimeKind.Local).AddTicks(6495) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);
        }
    }
}
