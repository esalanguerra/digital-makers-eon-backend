using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowToFolderRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario_id",
                table: "tokens_acesso");

            migrationBuilder.DropIndex(
                name: "IX_tokens_acesso_token_acesso_usuario_id",
                table: "tokens_acesso");

            migrationBuilder.RenameColumn(
                name: "nome_fluxo",
                table: "fluxos",
                newName: "fluxo_nome");

            migrationBuilder.AddColumn<int>(
                name: "token_acesso_usuario",
                table: "tokens_acesso",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fluxo_pasta_id",
                table: "fluxos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tokens_acesso_token_acesso_usuario",
                table: "tokens_acesso",
                column: "token_acesso_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_fluxos_fluxo_pasta_id",
                table: "fluxos",
                column: "fluxo_pasta_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fluxos_pastas_fluxo_pasta_id",
                table: "fluxos",
                column: "fluxo_pasta_id",
                principalTable: "pastas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario",
                table: "tokens_acesso",
                column: "token_acesso_usuario",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fluxos_pastas_fluxo_pasta_id",
                table: "fluxos");

            migrationBuilder.DropForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropIndex(
                name: "IX_tokens_acesso_token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropIndex(
                name: "IX_fluxos_fluxo_pasta_id",
                table: "fluxos");

            migrationBuilder.DropColumn(
                name: "token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropColumn(
                name: "fluxo_pasta_id",
                table: "fluxos");

            migrationBuilder.RenameColumn(
                name: "fluxo_nome",
                table: "fluxos",
                newName: "nome_fluxo");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_acesso_token_acesso_usuario_id",
                table: "tokens_acesso",
                column: "token_acesso_usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario_id",
                table: "tokens_acesso",
                column: "token_acesso_usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
