using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.SectorEntity; // Importa a classe Sector para o relacionamento

namespace Eon.Com.Domain.Models.Entity.TeamEntity
{
    [Table("times")]
    public class Team
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_time")]
        [Required]
        public string Name { get; set; }

        [Column("descricao_time")]
        [Required]
        public string Description { get; set; }

        [Column("sector_id")]
        public int SectorId { get; set; } // Chave estrangeira para o setor

        // Propriedade de navegação para o setor associado
        [ForeignKey(nameof(SectorId))]
        public virtual Sector Sector { get; set; }

        public Team()
        {
            Name = string.Empty;
            Description = string.Empty;
            SectorId = 0;
            Sector = new Sector();
        }

        public Team(string name, string description, int sectorId, Sector sector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            SectorId = sectorId;
            Sector = sector ?? throw new ArgumentNullException(nameof(sector));
        }
    }
}
