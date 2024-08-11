using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Users
{
    // Mapeia a classe Token para a tabela "tokens_acesso" no banco de dados
    [Table("tokens_acesso")]
    public class Token
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "token" como obrigatório
        [Column("token")]
        [Required]
        public string Value { get; set; }

        // Construtor padrão
        public Token()
        {
            Value = string.Empty; // Inicializa o Value como uma string vazia
        }

        // Construtor que inicializa a classe com um valor específico
        public Token(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value)); // Garante que o valor não seja nulo
        }
    }
}
