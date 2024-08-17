using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class AddSectorToTeamRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_time",
                table: "setores");

            migrationBuilder.AddColumn<int>(
                name: "sector_id",
                table: "times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "nome_setor",
                table: "setores",
                type: "text",
                nullable: false,
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.CreateIndex(
                name: "IX_times_sector_id",
                table: "times",
                column: "sector_id");

            migrationBuilder.AddForeignKey(
                name: "FK_times_setores_sector_id",
                table: "times",
                column: "sector_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_times_setores_sector_id",
                table: "times");

            migrationBuilder.DropIndex(
                name: "IX_times_sector_id",
                table: "times");

            migrationBuilder.DropColumn(
                name: "sector_id",
                table: "times");

            migrationBuilder.AlterColumn<string[]>(
                name: "nome_setor",
                table: "setores",
                type: "text[]",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "id_time",
                table: "setores",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
