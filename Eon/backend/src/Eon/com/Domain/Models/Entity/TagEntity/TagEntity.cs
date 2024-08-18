using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.SectorEntity;
using Eon.Com.Interfaces.Entities.TagEntity; // Importa a classe Sector para o relacionamento

namespace Eon.Com.Domain.Models.Entity.TagEntity
{
    [Table("etiquetas")] // Mapeia a classe para a tabela "etiquetas" no banco de dados
    public class Tag : ITagEntityInterface // Implementa a interface ITagEntityInterface
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("etiqueta_nome")] // Define o campo "name" na tabela
        [Required] // Torna o campo obrigatório
        public string Name { get; set; }

        [Column("etiqueta_descricao")] // Define o campo "description" na tabela
        public string Description { get; set; } // Pode ser nulo

        [Column("etiqueta_setor_id")] // Define o campo "sector_id" na tabela
        public int SectorId { get; set; } // Chave estrangeira para o setor

        // Propriedade de navegação para o setor associado
        [ForeignKey(nameof(SectorId))] // Define a relação de chave estrangeira com a tabela "sector"
        public virtual Sector Sector { get; set; }

        // Construtor padrão
        public Tag()
        {
            Name = string.Empty; // Inicializa Name como uma string vazia
            Description = string.Empty; // Inicializa Description como uma string vazia
            SectorId = 0; // Inicializa SectorId como 0
            Sector = new Sector(); // Inicializa Sector como uma nova instância de Sector
        }

        // Construtor que inicializa a classe com valores específicos
        public Tag(string name, string description, int sectorId, Sector sector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que Name não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que Description não seja nula
            SectorId = sectorId; // Inicializa SectorId
            Sector = sector ?? throw new ArgumentNullException(nameof(sector)); // Garante que Sector não seja nulo
        }
    }
}
