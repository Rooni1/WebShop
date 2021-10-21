using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class flerordrarinlagda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 10, 21, 10, 44, 59, 403, DateTimeKind.Local).AddTicks(2789));

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "OrderDate" },
                values: new object[] { 2, new DateTime(2021, 10, 21, 10, 44, 59, 408, DateTimeKind.Local).AddTicks(1237) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2021, 10, 21, 10, 43, 13, 916, DateTimeKind.Local).AddTicks(6495));
        }
    }
}
