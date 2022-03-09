using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAcces.Migrations
{
    public partial class newIs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orderds_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderds",
                table: "Orderds");

            migrationBuilder.RenameTable(
                name: "Orderds",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "IsWeek",
                table: "Products",
                newName: "IsPopular");

            migrationBuilder.RenameColumn(
                name: "IsMonth",
                table: "Products",
                newName: "IsBesSelled");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orderds");

            migrationBuilder.RenameColumn(
                name: "IsPopular",
                table: "Products",
                newName: "IsWeek");

            migrationBuilder.RenameColumn(
                name: "IsBesSelled",
                table: "Products",
                newName: "IsMonth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderds",
                table: "Orderds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orderds_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orderds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
