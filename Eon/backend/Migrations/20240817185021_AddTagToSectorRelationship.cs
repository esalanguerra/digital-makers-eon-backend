using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class AddTagToSectorRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "sector_id",
                table: "etiquetas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_etiquetas_sector_id",
                table: "etiquetas",
                column: "sector_id");

            migrationBuilder.AddForeignKey(
                name: "FK_etiquetas_setores_sector_id",
                table: "etiquetas",
                column: "sector_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etiquetas_setores_sector_id",
                table: "etiquetas");

            migrationBuilder.DropIndex(
                name: "IX_etiquetas_sector_id",
                table: "etiquetas");

            migrationBuilder.DropColumn(
                name: "sector_id",
                table: "etiquetas");
        }
    }
}
