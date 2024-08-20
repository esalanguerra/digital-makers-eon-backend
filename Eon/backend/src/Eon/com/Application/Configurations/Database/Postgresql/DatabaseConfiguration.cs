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
    /// <summary>
    /// Contexto principal para acesso ao banco de dados.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Construtor que recebe as opções de configuração do DbContext e as passa para a classe base.
        /// </summary>
        /// <param name="options">Opções de configuração para o DbContext.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet para a entidade User. Permite operações CRUD na tabela "usuarios".
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// DbSet para a entidade Folder. Permite operações CRUD na tabela "pastas".
        /// </summary>
        public DbSet<Folder> Folders { get; set; }

        /// <summary>
        /// DbSet para a entidade Flow. Permite operações CRUD na tabela "fluxos".
        /// </summary>
        public DbSet<Flow> Flows { get; set; }

        /// <summary>
        /// DbSet para a entidade Tag. Permite operações CRUD na tabela "etiquetas".
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// DbSet para a entidade Token. Permite operações CRUD na tabela "tokens_acesso".
        /// </summary>
        public DbSet<Token> Tokens { get; set; }

        /// <summary>
        /// DbSet para a entidade FlowShared. Permite operações CRUD na tabela "fluxos_compartilhados".
        /// </summary>
        public DbSet<FlowShared> FlowsShareds { get; set; }

        /// <summary>
        /// DbSet para a entidade MessageScheduling. Permite operações CRUD na tabela "mensagens_agendadas".
        /// </summary>
        public DbSet<MessageScheduling> MessagesSchedulings { get; set; }

        /// <summary>
        /// DbSet para a entidade Team. Permite operações CRUD na tabela "times".
        /// </summary>
        public DbSet<Team> Teams { get; set; }

        /// <summary>
        /// DbSet para a entidade Sector. Permite operações CRUD na tabela "setores".
        /// </summary>
        public DbSet<Sector> Sectors { get; set; }
    }
}
