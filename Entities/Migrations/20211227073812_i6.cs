using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class i6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OutBoundOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OutBoundOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OutBoundOrders_ProductId",
                table: "OutBoundOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutBoundOrders_Products_ProductId",
                table: "OutBoundOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutBoundOrders_Products_ProductId",
                table: "OutBoundOrders");

            migrationBuilder.DropIndex(
                name: "IX_OutBoundOrders_ProductId",
                table: "OutBoundOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OutBoundOrders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OutBoundOrders");
        }
    }
}
