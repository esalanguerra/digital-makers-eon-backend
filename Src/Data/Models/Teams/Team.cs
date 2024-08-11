using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Teams
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

        public Team()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public Team(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
