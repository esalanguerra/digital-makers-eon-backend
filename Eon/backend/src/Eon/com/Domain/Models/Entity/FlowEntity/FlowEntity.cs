using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.FolderEntity;
using Eon.Com.Interfaces.Entities.FlowEntity;

namespace Eon.Com.Domain.Models.Entity.FlowEntity
{
    // Mapeia a classe Flow para a tabela "fluxos" no banco de dados
    [Table("fluxos")]
    public class Flow : IFlowEntityInterface // Implementa a interface IFlowEntityInterface
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "nome_fluxo" como obrigatório
        [Column("fluxo_nome")]
        [Required]
        public string Name { get; set; }

        // Define o campo "folder_id" como chave estrangeira
        [Column("fluxo_pasta_id")]
        public int FolderId { get; set; }

        // Propriedade de navegação para Folder
        [ForeignKey(nameof(FolderId))]
        public Folder Folder { get; set; }

        // Construtor padrão
        public Flow()
        {
            Name = string.Empty; // Inicializa o Name como uma string vazia
            FolderId = 0; // Inicializa a chave estrangeira
            Folder = new Folder(); // Inicializa a propriedade de navegação
        }

        // Construtor que inicializa a classe com valores específicos
        public Flow(string name, int folderId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            FolderId = folderId; // Inicializa a chave estrangeira
            Folder = new Folder(); // Inicializa a propriedade de navegação
        }
    }
}
