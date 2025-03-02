using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preparation_bread_instance_BreadInstanceId",
                table: "preparation");

            migrationBuilder.DropIndex(
                name: "IX_preparation_BreadInstanceId",
                table: "preparation");

            migrationBuilder.DropColumn(
                name: "BreadInstanceId",
                table: "preparation");

            migrationBuilder.CreateTable(
                name: "bread_preparation_instance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BreadInstanceId = table.Column<int>(type: "integer", nullable: false),
                    PreparationId = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bread_preparation_instance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bread_preparation_instance_bread_instance_BreadInstanceId",
                        column: x => x.BreadInstanceId,
                        principalTable: "bread_instance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bread_preparation_instance_preparation_PreparationId",
                        column: x => x.PreparationId,
                        principalTable: "preparation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bread_preparation_instance_BreadInstanceId",
                table: "bread_preparation_instance",
                column: "BreadInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_bread_preparation_instance_PreparationId",
                table: "bread_preparation_instance",
                column: "PreparationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bread_preparation_instance");

            migrationBuilder.AddColumn<int>(
                name: "BreadInstanceId",
                table: "preparation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_preparation_BreadInstanceId",
                table: "preparation",
                column: "BreadInstanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_preparation_bread_instance_BreadInstanceId",
                table: "preparation",
                column: "BreadInstanceId",
                principalTable: "bread_instance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
