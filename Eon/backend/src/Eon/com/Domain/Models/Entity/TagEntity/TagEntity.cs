using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.SectorEntity; // Importa a classe Sector para o relacionamento

namespace Eon.Com.Domain.Models.Entity.TagEntity
{
    [Table("etiquetas")]
    public class Tag
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_etiqueta")]
        [Required]
        public string Name { get; set; }

        [Column("descricao_etiqueta")]
        public string Description { get; set; }

        // Chave estrangeira para o setor
        [Column("sector_id")]
        public int SectorId { get; set; } // Chave estrangeira para o setor

        // Propriedade de navegação para o setor associado
        [ForeignKey(nameof(SectorId))]
        public virtual Sector Sector { get; set; }

        // Construtor padrão
        public Tag()
        {
            Name = string.Empty;
            Description = string.Empty;
            SectorId = 0;
            Sector = new Sector(); // Inicializa a propriedade de navegação
        }

        // Construtor que inicializa a classe com valores específicos
        public Tag(string name, string description, int sectorId, Sector sector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que a descrição não seja nula
            SectorId = sectorId;
            Sector = sector ?? throw new ArgumentNullException(nameof(sector)); // Garante que o setor não seja nulo
        }
    }
}
