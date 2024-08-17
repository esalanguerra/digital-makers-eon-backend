using Eon.Com.Domain.Models.Entity.FlowEntity;
using Eon.Com.Domain.Models.Entity.FlowSharedEntity;
using Eon.Com.Domain.Models.Entity.FolderEntity;
using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity;
using Eon.Com.Domain.Models.Entity.SectorEntity;
using Eon.Com.Domain.Models.Entity.TagEntity;
using Eon.Com.Domain.Models.Entity.TeamEntity;
using Eon.Com.Domain.Models.Entity.TokenEntity;
using Eon.Com.Domain.Models.Entity.UserEntity;

using Microsoft.EntityFrameworkCore;

namespace Eon.Com.Application.Configurations.Database.Postgresql
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
        public DbSet<FlowShared> FlowsShareds { get; set; }

        // DbSet para entidade Mensagem Agendada (MessageScheduling). Permite operações CRUD na tabela "mensagens_agendadas".
        public DbSet<MessageScheduling> MessagesSchedulings { get; set; }

        // DbSet para entidade Times (Teams). Permite operações CRUD na tabela "times".
        public DbSet<Team> Teams { get; set; }

        // DbSet para entidade Setores (Sectors). Permite operações CRUD na tabela "setores".
        public DbSet<Sector> Sectors { get; internal set; }
    }
}
