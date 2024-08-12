using Eon.Data.Models.Flows;
using Eon.Data.Models.Folders;
using Eon.Data.Models.Messages;
using Eon.Data.Models.Tags;
using Eon.Data.Models.Teams;
using Eon.Data.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Eon.Configurations.Database
{
    // Contexto principal para acesso ao banco de dados.
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração do DbContext e as passa para a classe base.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para a entidade User. Permite operações CRUD na tabela "usuarios".
        public DbSet<User> Users { get; set; }

        // DbSet para a entidade Folder. Permite operações CRUD na tabela "pastas".
        public DbSet<Folder> Folders { get; set; }

        // DbSet para a entidade Flow. Permite operações CRUD na tabela "fluxos".
        public DbSet<Flow> Flows { get; set; }

        // DbSet para a entidade Tag. Permite operações CRUD na tabela "etiquetas".
        public DbSet<Tag> Tags { get; set; }

        // DbSet para a entidade Token. Permite operações CRUD na tabela "tokens_acesso".
        public DbSet<Token> Tokens { get; set; }

        // DbSet para entidade Fluxo Compartilhados (FlowsShared). Permite operações CRUD na tabela "fluxos_compartilhados".
        public DbSet<FlowShared> FlowsShared { get; set; }

        // DbSet para entidade Mensagem Agendada (MessageScheduling). Permite operações CRUD na tabela "mensagens_agendadas".
        public DbSet<MessageScheduling> MessageSchedulings { get; set; }

        // DbSet para entidade Times (Teams). Permite operações CRUD na tabela "times".
        public DbSet<Team> Teams { get; set; }
        public object Sectors { get; internal set; }
    }
}
