using System.Collections.Generic; // Importa a biblioteca para a coleção
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.TeamEntity;
using Eon.Com.Domain.Models.Entity.UserEntity; // Importa a classe User para o relacionamento
using Eon.Com.Domain.Models.Entity.FolderEntity; // Importa a classe Folder para o relacionamento

namespace Eon.Com.Domain.Models.Entity.SectorEntity
{
    [Table("setores")]
    public class Sector
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_setor")]
        [Required]
        public string Name { get; set; }

        [Column("descricao_setor")]
        [Required]
        public string Description { get; set; }

        [Column("user_business_id")]
        public int UserBusinessId { get; set; } // Chave estrangeira para o dono do setor

        // Propriedade de navegação para o usuário associado
        [ForeignKey(nameof(UserBusinessId))]
        public virtual User UserBusiness { get; set; }

        // Propriedade de navegação para os times associados
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        // Propriedade de navegação para as pastas associadas
        public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

        public Sector()
        {
            Name = string.Empty;
            Description = string.Empty;
            UserBusinessId = 0;
            UserBusiness = new User();
            Teams = new List<Team>();
            Folders = new List<Folder>();
        }

        public Sector(string name, string description, int userBusinessId, User userBusiness)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            UserBusinessId = userBusinessId;
            UserBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness));
            Teams = new List<Team>();
            Folders = new List<Folder>();
        }
    }
}
