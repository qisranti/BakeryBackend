using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredients_bread_instance_BreadInstanceId",
                table: "ingredients");

            migrationBuilder.DropIndex(
                name: "IX_ingredients_BreadInstanceId",
                table: "ingredients");

            migrationBuilder.DropColumn(
                name: "BreadInstanceId",
                table: "ingredients");

            migrationBuilder.CreateTable(
                name: "bread_ingredient_instance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BreadInstanceId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bread_ingredient_instance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bread_ingredient_instance_bread_instance_BreadInstanceId",
                        column: x => x.BreadInstanceId,
                        principalTable: "bread_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bread_ingredient_instance_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bread_ingredient_instance_BreadInstanceId",
                table: "bread_ingredient_instance",
                column: "BreadInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_bread_ingredient_instance_IngredientId",
                table: "bread_ingredient_instance",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bread_ingredient_instance");

            migrationBuilder.AddColumn<int>(
                name: "BreadInstanceId",
                table: "ingredients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_BreadInstanceId",
                table: "ingredients",
                column: "BreadInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredients_bread_instance_BreadInstanceId",
                table: "ingredients",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
