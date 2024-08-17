using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.UserDto
{
    public class UpdateUserRequestDTO
    {
        // Nome do usuário (opcional)
        public string? Name { get; set; }

        // E-mail do usuário (opcional)
        public string? Email { get; set; }

        // URL do avatar do usuário (opcional)
        public string? AvatarUrl { get; set; }

        // Número de WhatsApp do usuário (opcional)
        public string? PhoneWhatsapp { get; set; }

        // Endereço do usuário (opcional)
        public string? Address { get; set; }

        // Notas adicionais sobre o usuário (opcional)
        public string? Notes { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateUserRequestDTO(string? name = null, string? email = null, string? avatarUrl = null, string? phoneWhatsapp = null, string? address = null, string? notes = null)
        {
            Name = name;
            Email = email;
            AvatarUrl = avatarUrl;
            PhoneWhatsapp = phoneWhatsapp;
            Address = address;
            Notes = notes;
        }
    }
}
