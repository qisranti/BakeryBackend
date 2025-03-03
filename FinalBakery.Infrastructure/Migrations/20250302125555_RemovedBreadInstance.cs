using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBreadInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bread_bread_instance_BreadInstanceId",
                table: "bread");

            migrationBuilder.DropForeignKey(
                name: "FK_bread_ingredient_instance_bread_instance_BreadInstanceId",
                table: "bread_ingredient_instance");

            migrationBuilder.DropForeignKey(
                name: "FK_bread_preparation_instance_bread_instance_BreadInstanceId",
                table: "bread_preparation_instance");

            migrationBuilder.DropTable(
                name: "bread_instance");

            migrationBuilder.DropIndex(
                name: "IX_bread_BreadInstanceId",
                table: "bread");

            migrationBuilder.DropColumn(
                name: "BreadInstanceId",
                table: "bread");

            migrationBuilder.AddForeignKey(
                name: "FK_bread_ingredient_instance_bread_BreadInstanceId",
                table: "bread_ingredient_instance",
                column: "BreadInstanceId",
                principalTable: "bread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bread_preparation_instance_bread_BreadInstanceId",
                table: "bread_preparation_instance",
                column: "BreadInstanceId",
                principalTable: "bread",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bread_ingredient_instance_bread_BreadInstanceId",
                table: "bread_ingredient_instance");

            migrationBuilder.DropForeignKey(
                name: "FK_bread_preparation_instance_bread_BreadInstanceId",
                table: "bread_preparation_instance");

            migrationBuilder.AddColumn<int>(
                name: "BreadInstanceId",
                table: "bread",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "bread_instance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bread_instance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bread_instance_order_items_Id",
                        column: x => x.Id,
                        principalTable: "order_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bread_BreadInstanceId",
                table: "bread",
                column: "BreadInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_bread_bread_instance_BreadInstanceId",
                table: "bread",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bread_ingredient_instance_bread_instance_BreadInstanceId",
                table: "bread_ingredient_instance",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bread_preparation_instance_bread_instance_BreadInstanceId",
                table: "bread_preparation_instance",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
