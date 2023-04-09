using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrillingSupportWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_entities_navigate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Holes_DrillBlockId",
                table: "Holes",
                column: "DrillBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints",
                column: "HoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_HolePoints_Holes_HoleId",
                table: "HolePoints",
                column: "HoleId",
                principalTable: "Holes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Holes_DrillBlocks_DrillBlockId",
                table: "Holes",
                column: "DrillBlockId",
                principalTable: "DrillBlocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HolePoints_Holes_HoleId",
                table: "HolePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_Holes_DrillBlocks_DrillBlockId",
                table: "Holes");

            migrationBuilder.DropIndex(
                name: "IX_Holes_DrillBlockId",
                table: "Holes");

            migrationBuilder.DropIndex(
                name: "IX_HolePoints_HoleId",
                table: "HolePoints");
        }
    }
}
