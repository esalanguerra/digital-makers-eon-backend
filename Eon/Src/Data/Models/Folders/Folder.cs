using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Folders
{
    // Mapeia a classe Folder para a tabela "pastas" no banco de dados
    [Table("pastas")]
    public class Folder
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "nome_pasta" como obrigatório
        [Column("nome_pasta")]
        [Required]
        public string Name { get; set; }

        // Construtor padrão
        public Folder()
        {
            Name = string.Empty;
        }

        // Construtor que inicializa a classe com um valor específico
        public Folder(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
        }
    }
}
