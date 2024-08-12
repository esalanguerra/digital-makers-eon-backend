using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Sectors
{
    [Table("setores")]
    public class Sector
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome_setor")]
        [Required]
        public string[] Team { get; set; }

        [Column("descricao_setor")]
        [Required]
        public string Description { get; set; }

        [Column("id_time")]
        [Required]
        public int TeamId { get; set; }

        public Sector()
        {
            Team = new string[0];
            Description = string.Empty;
            TeamId = 0;
        }

        public Sector(string[] team, string description, int teamId)
        {
            Team = team ?? throw new ArgumentNullException(nameof(team));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            TeamId = teamId;
        }
    }
}
