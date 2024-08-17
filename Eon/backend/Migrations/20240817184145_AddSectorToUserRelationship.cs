using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class AddSectorToUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_business_id",
                table: "setores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_setores_user_business_id",
                table: "setores",
                column: "user_business_id");

            migrationBuilder.AddForeignKey(
                name: "FK_setores_usuarios_user_business_id",
                table: "setores",
                column: "user_business_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_setores_usuarios_user_business_id",
                table: "setores");

            migrationBuilder.DropIndex(
                name: "IX_setores_user_business_id",
                table: "setores");

            migrationBuilder.DropColumn(
                name: "user_business_id",
                table: "setores");
        }
    }
}
