using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bread",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bread_name = table.Column<string>(type: "text", nullable: false),
                    BreadInstanceId = table.Column<int>(type: "integer", nullable: false),
                    Bread_Cost = table.Column<float>(type: "real", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bread", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chef_name = table.Column<string>(type: "text", nullable: false),
                    SpecialtyBreadId = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chefs_bread_SpecialtyBreadId",
                        column: x => x.SpecialtyBreadId,
                        principalTable: "bread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "office",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    office_name = table.Column<string>(type: "text", nullable: false),
                    office_capacity = table.Column<int>(type: "integer", nullable: false),
                    ChefId = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_office_chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "chefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "office_bread",
                columns: table => new
                {
                    OfficeId = table.Column<int>(type: "integer", nullable: false),
                    BreadId = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office_bread", x => new { x.OfficeId, x.BreadId });
                    table.ForeignKey(
                        name: "FK_office_bread_bread_BreadId",
                        column: x => x.BreadId,
                        principalTable: "bread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_office_bread_office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OfficeId = table.Column<int>(type: "integer", nullable: false),
                    order_total_cost = table.Column<float>(type: "real", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    BreadId = table.Column<int>(type: "integer", nullable: false),
                    order_item_cost = table.Column<float>(type: "real", nullable: false),
                    order_item_quantity = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BreadEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_items_bread_BreadEntityId",
                        column: x => x.BreadEntityId,
                        principalTable: "bread",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_order_items_bread_BreadId",
                        column: x => x.BreadId,
                        principalTable: "bread",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_items_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bread_instance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BreadInstanceId = table.Column<int>(type: "integer", nullable: false),
                    ingredient_name = table.Column<string>(type: "text", nullable: false),
                    ingredient_quantity = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingredients_bread_instance_BreadInstanceId",
                        column: x => x.BreadInstanceId,
                        principalTable: "bread_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "preparation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BreadInstanceId = table.Column<int>(type: "integer", nullable: false),
                    step_name = table.Column<string>(type: "text", nullable: false),
                    step_duration = table.Column<float>(type: "real", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_preparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_preparation_bread_instance_BreadInstanceId",
                        column: x => x.BreadInstanceId,
                        principalTable: "bread_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bread_BreadInstanceId",
                table: "bread",
                column: "BreadInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_chefs_SpecialtyBreadId",
                table: "chefs",
                column: "SpecialtyBreadId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_BreadInstanceId",
                table: "ingredients",
                column: "BreadInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_office_ChefId",
                table: "office",
                column: "ChefId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_office_bread_BreadId",
                table: "office_bread",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_BreadEntityId",
                table: "order_items",
                column: "BreadEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_BreadId",
                table: "order_items",
                column: "BreadId");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_OrderId",
                table: "order_items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OfficeId",
                table: "orders",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_preparation_BreadInstanceId",
                table: "preparation",
                column: "BreadInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_bread_bread_instance_BreadInstanceId",
                table: "bread",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bread_bread_instance_BreadInstanceId",
                table: "bread");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "office_bread");

            migrationBuilder.DropTable(
                name: "preparation");

            migrationBuilder.DropTable(
                name: "bread_instance");

            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "office");

            migrationBuilder.DropTable(
                name: "chefs");

            migrationBuilder.DropTable(
                name: "bread");
        }
    }
}
