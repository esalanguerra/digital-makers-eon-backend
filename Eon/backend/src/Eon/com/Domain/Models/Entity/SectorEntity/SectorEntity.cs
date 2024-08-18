using System.Collections.Generic; // Importa a biblioteca para a coleção
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.TeamEntity;
using Eon.Com.Domain.Models.Entity.UserEntity; // Importa a classe User para o relacionamento
using Eon.Com.Domain.Models.Entity.FolderEntity; // Importa a classe Folder para o relacionamento

namespace Eon.Com.Domain.Models.Entity.SectorEntity
{
    [Table("setores")] // Mapeia a classe para a tabela "setores" no banco de dados
    public class Sector
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("setor_nome")] // Define o campo "name" na tabela
        [Required] // Torna o campo obrigatório
        public string Name { get; set; }

        [Column("setor_descricao")] // Define o campo "description" na tabela
        [Required] // Torna o campo obrigatório
        public string Description { get; set; }

        [Column("setor_usuario_responsavel_id")] // Define o campo "user_business_id" na tabela
        public int UserBusinessId { get; set; } // Chave estrangeira para o dono do setor

        // Propriedade de navegação para o usuário associado
        [ForeignKey(nameof(UserBusinessId))] // Define a relação de chave estrangeira com a tabela "usuarios"
        public virtual User UserBusiness { get; set; }

        // Propriedade de navegação para os times associados
        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        // Propriedade de navegação para as pastas associadas
        public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();

        // Construtor padrão
        public Sector()
        {
            Name = string.Empty; // Inicializa Name como uma string vazia
            Description = string.Empty; // Inicializa Description como uma string vazia
            UserBusinessId = 0; // Inicializa UserBusinessId como 0
            UserBusiness = new User(); // Inicializa UserBusiness como uma nova instância de User
            Teams = new List<Team>(); // Inicializa a coleção de Teams
            Folders = new List<Folder>(); // Inicializa a coleção de Folders
        }

        // Construtor que inicializa a classe com valores específicos
        public Sector(string name, string description, int userBusinessId, User userBusiness)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que Name não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que Description não seja nula
            UserBusinessId = userBusinessId; // Inicializa UserBusinessId
            UserBusiness = userBusiness ?? throw new ArgumentNullException(nameof(userBusiness)); // Garante que UserBusiness não seja nulo
            Teams = new List<Team>(); // Inicializa a coleção de Teams
            Folders = new List<Folder>(); // Inicializa a coleção de Folders
        }
    }
}
