using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.SectorEntity; // Importa a classe Sector para o relacionamento

namespace Eon.Com.Domain.Models.Entity.FolderEntity
{
    [Table("pastas")] // Mapeia a classe para a tabela "pastas" no banco de dados
    public class Folder
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("pasta_nome")] // Define o campo "name" na tabela como "pasta_nome"
        [Required] // Torna o campo obrigatório
        public string Name { get; set; }

        // Chave estrangeira para o setor
        [Column("pasta_setor_id")] // Define o campo "sector_id" na tabela como "pasta_setor_id"
        public int SectorId { get; set; } // Chave estrangeira para o setor

        // Propriedade de navegação para o setor associado
        [ForeignKey(nameof(SectorId))] // Define a relação de chave estrangeira com a tabela "setores"
        public virtual Sector Sector { get; set; }

        // Construtor padrão
        public Folder()
        {
            Name = string.Empty; // Inicializa Name como uma string vazia
            SectorId = 0; // Inicializa SectorId como 0
            Sector = new Sector(); // Inicializa a propriedade de navegação Sector
        }

        // Construtor que inicializa a classe com valores específicos
        public Folder(string name, int sectorId, Sector sector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            SectorId = sectorId; // Inicializa SectorId
            Sector = sector ?? throw new ArgumentNullException(nameof(sector)); // Garante que o setor não seja nulo
        }
    }
}
