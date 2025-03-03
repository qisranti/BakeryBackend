using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "step_order",
                table: "preparation",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "step_order",
                table: "preparation");
        }
    }
}
