using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DrillingSupportWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_DrillBlock_navigate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillBlockPoints_DrillBlockPoints_Sequence",
                table: "DrillBlockPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_DrillBlockPoints_DrillBlock_DrillBlockId",
                table: "DrillBlockPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_HolePoints_Hole_HoleId",
                table: "HolePoints");

            migrationBuilder.DropTable(
                name: "Hole");

            migrationBuilder.DropTable(
                name: "DrillBlock");

            migrationBuilder.DropIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints");

            migrationBuilder.DropIndex(
                name: "IX_DrillBlockPoints_Sequence",
                table: "DrillBlockPoints");

            migrationBuilder.CreateTable(
                name: "DrillBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: true),
                    DEPTH = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DrillBlockPoints_DrillBlocks_DrillBlockId",
                table: "DrillBlockPoints",
                column: "DrillBlockId",
                principalTable: "DrillBlocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillBlockPoints_DrillBlocks_DrillBlockId",
                table: "DrillBlockPoints");

            migrationBuilder.DropTable(
                name: "DrillBlocks");

            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.CreateTable(
                name: "DrillBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DEPTH = table.Column<double>(type: "double precision", nullable: true),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hole_DrillBlock_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlock",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints",
                column: "HoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPoints_Sequence",
                table: "DrillBlockPoints",
                column: "Sequence",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hole_DrillBlockId",
                table: "Hole",
                column: "DrillBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillBlockPoints_DrillBlockPoints_Sequence",
                table: "DrillBlockPoints",
                column: "Sequence",
                principalTable: "DrillBlockPoints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillBlockPoints_DrillBlock_DrillBlockId",
                table: "DrillBlockPoints",
                column: "DrillBlockId",
                principalTable: "DrillBlock",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HolePoints_Hole_HoleId",
                table: "HolePoints",
                column: "HoleId",
                principalTable: "Hole",
                principalColumn: "Id");
        }
    }
}
