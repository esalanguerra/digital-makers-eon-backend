using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.SectorEntity; // Importa a classe Sector para o relacionamento

namespace Eon.Com.Domain.Models.Entity.FolderEntity
{
    [Table("pastas")]
    public class Folder
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_pasta")]
        [Required]
        public string Name { get; set; }

        // Chave estrangeira para o setor
        [Column("setor_id")]
        public int SectorId { get; set; } // Chave estrangeira para o setor

        // Propriedade de navegação para o setor associado
        [ForeignKey(nameof(SectorId))]
        public virtual Sector Sector { get; set; }

        // Construtor padrão
        public Folder()
        {
            Name = string.Empty;
            SectorId = 0;
            Sector = new Sector();
        }

        // Construtor que inicializa a classe com valores específicos
        public Folder(string name, int sectorId, Sector sector)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            SectorId = sectorId;
            Sector = sector ?? throw new ArgumentNullException(nameof(sector)); // Garante que o setor não seja nulo
        }
    }
}
