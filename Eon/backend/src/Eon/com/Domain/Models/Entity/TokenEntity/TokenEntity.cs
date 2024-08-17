using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.UserEntity;

namespace Eon.Com.Domain.Models.Entity.TokenEntity
{
    [Table("tokens_acesso")] // Mapeia a classe para a tabela "tokens_acesso" no banco de dados
    public class Token
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("token_acesso_valor")] // Define o campo "token" na tabela
        [Required] // Torna o campo obrigatório
        public string Value { get; set; }

        // Chave estrangeira para User
        [Column("token_acesso_usuario_id")] // Define o campo de chave estrangeira na tabela
        public int UserId { get; set; }

        // Propriedade de navegação para o User associado
        [ForeignKey(nameof(UserId))] // Define a chave estrangeira
        public virtual User User { get; set; }

        // Construtor padrão
        public Token()
        {
            Value = string.Empty; // Inicializa o Value como uma string vazia
            UserId = 0; // Inicializa UserId como 0
            User = new User(); // Inicializa User como uma nova instância de User
        }

        // Construtor que inicializa a classe com valores específicos
        public Token(string value, int userId)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value)); // Garante que o valor não seja nulo
            UserId = userId; // Inicializa UserId
            User = new User(); // Inicializa User como uma nova instância de User
        }
    }
}
