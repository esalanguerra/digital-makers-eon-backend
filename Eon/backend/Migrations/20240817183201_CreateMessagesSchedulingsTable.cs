using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace tests_.Migrations
{
    /// <inheritdoc />
    public partial class CreateMessagesSchedulingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mensagens_agendadas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mensagem_de_texto = table.Column<string>(type: "text", nullable: false),
                    id_etiqueta = table.Column<string>(type: "text", nullable: false),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    data_envio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    id_fluxo = table.Column<string>(type: "text", nullable: false),
                    numero_whatsapp = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensagens_agendadas", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mensagens_agendadas");
        }
    }
}
