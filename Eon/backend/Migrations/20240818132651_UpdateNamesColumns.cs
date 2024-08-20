using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etiquetas_setores_sector_id",
                table: "etiquetas");

            migrationBuilder.DropForeignKey(
                name: "FK_setores_usuarios_user_business_id",
                table: "setores");

            migrationBuilder.DropForeignKey(
                name: "FK_times_setores_sector_id",
                table: "times");

            migrationBuilder.DropForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_times_team_id",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_usuarios_team_id",
                table: "usuarios");

            migrationBuilder.DropIndex(
                name: "IX_tokens_acesso_token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropColumn(
                name: "team_id",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "token_acesso_usuario",
                table: "tokens_acesso");

            migrationBuilder.DropColumn(
                name: "id_etiqueta",
                table: "mensagens_agendadas");

            migrationBuilder.DropColumn(
                name: "id_fluxo",
                table: "mensagens_agendadas");

            migrationBuilder.RenameColumn(
                name: "sector_id",
                table: "times",
                newName: "time_setor_id");

            migrationBuilder.RenameColumn(
                name: "nome_time",
                table: "times",
                newName: "time_nome");

            migrationBuilder.RenameColumn(
                name: "descricao_time",
                table: "times",
                newName: "time_descricao");

            migrationBuilder.RenameIndex(
                name: "IX_times_sector_id",
                table: "times",
                newName: "IX_times_time_setor_id");

            migrationBuilder.RenameColumn(
                name: "user_business_id",
                table: "setores",
                newName: "setor_usuario_responsavel_id");

            migrationBuilder.RenameColumn(
                name: "nome_setor",
                table: "setores",
                newName: "setor_nome");

            migrationBuilder.RenameColumn(
                name: "descricao_setor",
                table: "setores",
                newName: "setor_descricao");

            migrationBuilder.RenameIndex(
                name: "IX_setores_user_business_id",
                table: "setores",
                newName: "IX_setores_setor_usuario_responsavel_id");

            migrationBuilder.RenameColumn(
                name: "nome_pasta",
                table: "pastas",
                newName: "pasta_nome");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "mensagens_agendadas",
                newName: "mensagem_agendada_status");

            migrationBuilder.RenameColumn(
                name: "numero_whatsapp",
                table: "mensagens_agendadas",
                newName: "mensagem_agendada_numero_whatsapp");

            migrationBuilder.RenameColumn(
                name: "mensagem_de_texto",
                table: "mensagens_agendadas",
                newName: "mensagem_agendada_mensagem_de_texto");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "mensagens_agendadas",
                newName: "mensagem_agendada_usuario_id");

            migrationBuilder.RenameColumn(
                name: "data_envio",
                table: "mensagens_agendadas",
                newName: "mensagem_agendada_data_envio");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "fluxos_compartilhados",
                newName: "fluxo_compartilhado_status");

            migrationBuilder.RenameColumn(
                name: "link",
                table: "fluxos_compartilhados",
                newName: "fluxo_compartilhado_link");

            migrationBuilder.RenameColumn(
                name: "id_usuario",
                table: "fluxos_compartilhados",
                newName: "fluxo_compartilhado_usuario_id");

            migrationBuilder.RenameColumn(
                name: "id_fluxo",
                table: "fluxos_compartilhados",
                newName: "fluxo_compartilhado_fluxo_id");

            migrationBuilder.RenameColumn(
                name: "sector_id",
                table: "etiquetas",
                newName: "etiqueta_setor_id");

            migrationBuilder.RenameColumn(
                name: "nome_etiqueta",
                table: "etiquetas",
                newName: "etiqueta_nome");

            migrationBuilder.RenameColumn(
                name: "descricao_etiqueta",
                table: "etiquetas",
                newName: "etiqueta_descricao");

            migrationBuilder.RenameIndex(
                name: "IX_etiquetas_sector_id",
                table: "etiquetas",
                newName: "IX_etiquetas_etiqueta_setor_id");

            migrationBuilder.AddColumn<int>(
                name: "pasta_setor_id",
                table: "pastas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tokens_acesso_token_acesso_usuario_id",
                table: "tokens_acesso",
                column: "token_acesso_usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_pastas_pasta_setor_id",
                table: "pastas",
                column: "pasta_setor_id");

            migrationBuilder.CreateIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_etiqueta_id");

            migrationBuilder.CreateIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_fluxo_id");

            migrationBuilder.CreateIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_usuario_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_etiquetas_setores_etiqueta_setor_id",
                table: "etiquetas",
                column: "etiqueta_setor_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagens_agendadas_etiquetas_mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_etiqueta_id",
                principalTable: "etiquetas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagens_agendadas_fluxos_mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_fluxo_id",
                principalTable: "fluxos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_mensagens_agendadas_usuarios_mensagem_agendada_usuario_id",
                table: "mensagens_agendadas",
                column: "mensagem_agendada_usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pastas_setores_pasta_setor_id",
                table: "pastas",
                column: "pasta_setor_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_setores_usuarios_setor_usuario_responsavel_id",
                table: "setores",
                column: "setor_usuario_responsavel_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_times_setores_time_setor_id",
                table: "times",
                column: "time_setor_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario_id",
                table: "tokens_acesso",
                column: "token_acesso_usuario_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_etiquetas_setores_etiqueta_setor_id",
                table: "etiquetas");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagens_agendadas_etiquetas_mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagens_agendadas_fluxos_mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_mensagens_agendadas_usuarios_mensagem_agendada_usuario_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropForeignKey(
                name: "FK_pastas_setores_pasta_setor_id",
                table: "pastas");

            migrationBuilder.DropForeignKey(
                name: "FK_setores_usuarios_setor_usuario_responsavel_id",
                table: "setores");

            migrationBuilder.DropForeignKey(
                name: "FK_times_setores_time_setor_id",
                table: "times");

            migrationBuilder.DropForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario_id",
                table: "tokens_acesso");

            migrationBuilder.DropIndex(
                name: "IX_tokens_acesso_token_acesso_usuario_id",
                table: "tokens_acesso");

            migrationBuilder.DropIndex(
                name: "IX_pastas_pasta_setor_id",
                table: "pastas");

            migrationBuilder.DropIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropIndex(
                name: "IX_mensagens_agendadas_mensagem_agendada_usuario_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropColumn(
                name: "pasta_setor_id",
                table: "pastas");

            migrationBuilder.DropColumn(
                name: "mensagem_agendada_etiqueta_id",
                table: "mensagens_agendadas");

            migrationBuilder.DropColumn(
                name: "mensagem_agendada_fluxo_id",
                table: "mensagens_agendadas");

            migrationBuilder.RenameColumn(
                name: "time_setor_id",
                table: "times",
                newName: "sector_id");

            migrationBuilder.RenameColumn(
                name: "time_nome",
                table: "times",
                newName: "nome_time");

            migrationBuilder.RenameColumn(
                name: "time_descricao",
                table: "times",
                newName: "descricao_time");

            migrationBuilder.RenameIndex(
                name: "IX_times_time_setor_id",
                table: "times",
                newName: "IX_times_sector_id");

            migrationBuilder.RenameColumn(
                name: "setor_usuario_responsavel_id",
                table: "setores",
                newName: "user_business_id");

            migrationBuilder.RenameColumn(
                name: "setor_nome",
                table: "setores",
                newName: "nome_setor");

            migrationBuilder.RenameColumn(
                name: "setor_descricao",
                table: "setores",
                newName: "descricao_setor");

            migrationBuilder.RenameIndex(
                name: "IX_setores_setor_usuario_responsavel_id",
                table: "setores",
                newName: "IX_setores_user_business_id");

            migrationBuilder.RenameColumn(
                name: "pasta_nome",
                table: "pastas",
                newName: "nome_pasta");

            migrationBuilder.RenameColumn(
                name: "mensagem_agendada_usuario_id",
                table: "mensagens_agendadas",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "mensagem_agendada_status",
                table: "mensagens_agendadas",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "mensagem_agendada_numero_whatsapp",
                table: "mensagens_agendadas",
                newName: "numero_whatsapp");

            migrationBuilder.RenameColumn(
                name: "mensagem_agendada_mensagem_de_texto",
                table: "mensagens_agendadas",
                newName: "mensagem_de_texto");

            migrationBuilder.RenameColumn(
                name: "mensagem_agendada_data_envio",
                table: "mensagens_agendadas",
                newName: "data_envio");

            migrationBuilder.RenameColumn(
                name: "fluxo_compartilhado_usuario_id",
                table: "fluxos_compartilhados",
                newName: "id_usuario");

            migrationBuilder.RenameColumn(
                name: "fluxo_compartilhado_status",
                table: "fluxos_compartilhados",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "fluxo_compartilhado_link",
                table: "fluxos_compartilhados",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "fluxo_compartilhado_fluxo_id",
                table: "fluxos_compartilhados",
                newName: "id_fluxo");

            migrationBuilder.RenameColumn(
                name: "etiqueta_setor_id",
                table: "etiquetas",
                newName: "sector_id");

            migrationBuilder.RenameColumn(
                name: "etiqueta_nome",
                table: "etiquetas",
                newName: "nome_etiqueta");

            migrationBuilder.RenameColumn(
                name: "etiqueta_descricao",
                table: "etiquetas",
                newName: "descricao_etiqueta");

            migrationBuilder.RenameIndex(
                name: "IX_etiquetas_etiqueta_setor_id",
                table: "etiquetas",
                newName: "IX_etiquetas_sector_id");

            migrationBuilder.AddColumn<int>(
                name: "team_id",
                table: "usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "token_acesso_usuario",
                table: "tokens_acesso",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "id_etiqueta",
                table: "mensagens_agendadas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "id_fluxo",
                table: "mensagens_agendadas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_team_id",
                table: "usuarios",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_acesso_token_acesso_usuario",
                table: "tokens_acesso",
                column: "token_acesso_usuario");

            migrationBuilder.AddForeignKey(
                name: "FK_etiquetas_setores_sector_id",
                table: "etiquetas",
                column: "sector_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_setores_usuarios_user_business_id",
                table: "setores",
                column: "user_business_id",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_times_setores_sector_id",
                table: "times",
                column: "sector_id",
                principalTable: "setores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tokens_acesso_usuarios_token_acesso_usuario",
                table: "tokens_acesso",
                column: "token_acesso_usuario",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_times_team_id",
                table: "usuarios",
                column: "team_id",
                principalTable: "times",
                principalColumn: "id");
        }
    }
}
