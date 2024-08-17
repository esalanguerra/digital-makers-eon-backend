using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity;
using Eon.Com.Domain.Models.Entity.TokenEntity;
using Eon.Com.Interfaces.Entities.UserEntity;

namespace Eon.Com.Domain.Models.Entity.UserEntity
{
    [Table("usuarios")] // Mapeia a classe para a tabela "usuarios" no banco de dados
    public class User : UserEntityInterface
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_nome")] // Define o campo "nome" na tabela
        [Required] // Torna o campo obrigatório
        public string Name { get; set; }

        [Column("usuario_email")] // Define o campo "email" na tabela
        [Required] // Torna o campo obrigatório
        public string Email { get; set; }

        [Column("usuario_avatar_url")] // Define o campo "avatar_url" na tabela
        public string? AvatarUrl { get; set; } // Pode ser nulo

        [Column("usuario_numero_whatsapp")] // Define o campo "phone_whatsapp" na tabela
        [Required] // Torna o campo obrigatório
        public string PhoneWhatsapp { get; set; }

        [Column("usuario_endereco")] // Define o campo "address" na tabela
        [Required] // Torna o campo obrigatório
        public string Address { get; set; }

        [Column("usuario_anotacoes")] // Define o campo "notes" na tabela
        public string? Notes { get; set; } // Pode ser nulo

        // Propriedade de navegação para os Tokens associados a este usuário
        public ICollection<Token> Tokens { get; set; } = new List<Token>();

        // Propriedade de navegação para as Mensagens Agendadas associadas a este usuário
        public ICollection<MessageScheduling> MessageSchedulings { get; set; } = new List<MessageScheduling>();

        // Construtor padrão
        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            AvatarUrl = string.Empty;
            PhoneWhatsapp = string.Empty;
            Address = string.Empty;
            Notes = string.Empty;
            MessageSchedulings = new List<MessageScheduling>(); // Inicializa a coleção
        }

        // Construtor que inicializa a classe com valores específicos
        public User(string name, string email, string phoneWhatsapp, string address, string? avatarUrl = null, string? notes = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Email = email ?? throw new ArgumentNullException(nameof(email)); // Garante que o e-mail não seja nulo
            PhoneWhatsapp = phoneWhatsapp ?? throw new ArgumentNullException(nameof(phoneWhatsapp)); // Garante que o número de WhatsApp não seja nulo
            Address = address ?? throw new ArgumentNullException(nameof(address)); // Garante que o endereço não seja nulo
            AvatarUrl = avatarUrl; // Pode ser nulo
            Notes = notes; // Pode ser nulo
            MessageSchedulings = new List<MessageScheduling>(); // Inicializa a coleção
        }
    }
}
