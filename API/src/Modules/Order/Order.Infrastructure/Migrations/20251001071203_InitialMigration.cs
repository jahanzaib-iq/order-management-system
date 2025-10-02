using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "order");

            migrationBuilder.CreateTable(
                name: "__OrderSeedingEntry",
                schema: "order",
                columns: table => new
                {
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___OrderSeedingEntry", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "order",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    product = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "order",
                        principalTable: "OrderStatus",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_StatusId",
                schema: "order",
                table: "OrderDetails",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__OrderSeedingEntry",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "order");

            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "order");
        }
    }
}
