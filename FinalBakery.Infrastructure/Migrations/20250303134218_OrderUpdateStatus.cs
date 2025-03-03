using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order_Status",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_Status",
                table: "orders");
        }
    }
}
