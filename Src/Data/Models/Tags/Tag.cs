using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Tags
{
    // Mapeia a classe Tag para a tabela "etiquetas" no banco de dados
    [Table("etiquetas")]
    public class Tag
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "nome_etiqueta" como obrigatório
        [Column("nome_etiqueta")]
        [Required]
        public string Name { get; set; }

        // Define o campo "descricao_etiqueta"
        [Column("descricao_etiqueta")]
        public string Description { get; set; }

        // Construtor padrão
        public Tag()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        // Construtor que inicializa a classe com valores específicos
        public Tag(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que a descrição não seja nula
        }
    }
}
