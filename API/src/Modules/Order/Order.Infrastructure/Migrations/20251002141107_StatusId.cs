using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderStatus_StatusId",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_StatusId",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "StatusId",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "order",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "customer_name",
                schema: "order",
                table: "OrderDetails",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_status_id",
                schema: "order",
                table: "OrderDetails",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderStatus_status_id",
                schema: "order",
                table: "OrderDetails",
                column: "status_id",
                principalSchema: "order",
                principalTable: "OrderStatus",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderStatus_status_id",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_status_id",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "customer_name",
                schema: "order",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "status_id",
                schema: "order",
                table: "OrderDetails",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                schema: "order",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_StatusId",
                schema: "order",
                table: "OrderDetails",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderStatus_StatusId",
                schema: "order",
                table: "OrderDetails",
                column: "StatusId",
                principalSchema: "order",
                principalTable: "OrderStatus",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
