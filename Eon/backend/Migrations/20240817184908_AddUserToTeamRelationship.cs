using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToTeamRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_team_id",
                table: "usuarios",
                column: "team_id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_times_team_id",
                table: "usuarios",
                column: "team_id",
                principalTable: "times",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_times_team_id",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_team_id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "usuarios");
        }
    }
}
