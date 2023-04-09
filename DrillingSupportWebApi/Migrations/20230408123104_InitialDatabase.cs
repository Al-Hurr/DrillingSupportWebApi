using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DrillingSupportWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DrillBlockPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DrillBlockId = table.Column<int>(type: "integer", nullable: true),
                    Sequence = table.Column<int>(type: "integer", nullable: true),
                    X = table.Column<double>(type: "double precision", nullable: true),
                    Y = table.Column<double>(type: "double precision", nullable: true),
                    Z = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillBlockPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillBlockPoints_DrillBlockPoints_Sequence",
                        column: x => x.Sequence,
                        principalTable: "DrillBlockPoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DrillBlockPoints_DrillBlock_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlock",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hole",
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
                    table.PrimaryKey("PK_Hole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hole_DrillBlock_DrillBlockId",
                        column: x => x.DrillBlockId,
                        principalTable: "DrillBlock",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HolePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoleId = table.Column<int>(type: "integer", nullable: true),
                    X = table.Column<double>(type: "double precision", nullable: true),
                    Y = table.Column<double>(type: "double precision", nullable: true),
                    Z = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolePoints_Hole_HoleId",
                        column: x => x.HoleId,
                        principalTable: "Hole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPoints_DrillBlockId",
                table: "DrillBlockPoints",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillBlockPoints_Sequence",
                table: "DrillBlockPoints",
                column: "Sequence",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hole_DrillBlockId",
                table: "Hole",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints",
                column: "HoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillBlockPoints");

            migrationBuilder.DropTable(
                name: "HolePoints");

            migrationBuilder.DropTable(
                name: "Hole");

            migrationBuilder.DropTable(
                name: "DrillBlock");
        }
    }
}
