using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Users
{
    // Mapeia a classe User para a tabela "usuarios" no banco de dados
    [Table("usuarios")]
    public class User
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "nome" como obrigatório
        [Column("nome")]
        [Required]
        public string Name { get; set; }

        // Define o campo "email" como obrigatório
        [Column("email")]
        [Required]
        public string Email { get; set; }

        // Construtor padrão
        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
        }

        // Construtor que inicializa a classe com valores específicos
        public User(string name, string email)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Email = email ?? throw new ArgumentNullException(nameof(email)); // Garante que o e-mail não seja nulo
        }
    }
}
