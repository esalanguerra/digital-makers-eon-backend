using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.UserDto
{
    /// <summary>
    /// DTO para a atualização das informações de um usuário.
    /// </summary>
    public class UpdateUserRequestDTO
    {
        /// <summary>
        /// Nome do usuário. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// E-mail do usuário. Este campo é opcional.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// URL do avatar do usuário. Este campo é opcional.
        /// </summary>
        public string? AvatarUrl { get; set; }

        /// <summary>
        /// Número de WhatsApp do usuário. Este campo é opcional.
        /// </summary>
        public string? PhoneWhatsapp { get; set; }

        /// <summary>
        /// Endereço do usuário. Este campo é opcional.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Notas adicionais sobre o usuário. Este campo é opcional.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="avatarUrl">URL do avatar do usuário.</param>
        /// <param name="phoneWhatsapp">Número de WhatsApp do usuário.</param>
        /// <param name="address">Endereço do usuário.</param>
        /// <param name="notes">Notas adicionais sobre o usuário.</param>
        [JsonConstructor]
        public UpdateUserRequestDTO(
            string? name = null, 
            string? email = null, 
            string? avatarUrl = null, 
            string? phoneWhatsapp = null, 
            string? address = null, 
            string? notes = null)
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
