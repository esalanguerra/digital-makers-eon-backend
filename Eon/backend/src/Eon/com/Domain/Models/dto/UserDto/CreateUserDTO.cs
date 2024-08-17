using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.UserDto
{
    /// <summary>
    /// DTO para a criação de um novo usuário.
    /// </summary>
    public class CreateUserRequestDTO
    {
        /// <summary>
        /// Identificador único do usuário. Este campo é obrigatório.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do usuário. Este campo é obrigatório.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// E-mail do usuário. Este campo é obrigatório.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// URL do avatar do usuário. Este campo é opcional.
        /// </summary>
        public string? AvatarUrl { get; set; }

        /// <summary>
        /// Número de WhatsApp do usuário. Este campo é obrigatório.
        /// </summary>
        public string PhoneWhatsapp { get; set; }

        /// <summary>
        /// Endereço do usuário. Este campo é obrigatório.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Notas adicionais sobre o usuário. Este campo é opcional.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="phoneWhatsapp">Número de WhatsApp do usuário.</param>
        /// <param name="address">Endereço do usuário.</param>
        /// <param name="avatarUrl">URL do avatar do usuário.</param>
        /// <param name="notes">Notas adicionais sobre o usuário.</param>
        [JsonConstructor]
        public CreateUserRequestDTO(
            int id, 
            string name, 
            string email, 
            string phoneWhatsapp, 
            string address, 
            string? avatarUrl = null, 
            string? notes = null)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Email = email ?? throw new ArgumentNullException(nameof(email)); // Garante que o e-mail não seja nulo
            PhoneWhatsapp = phoneWhatsapp ?? throw new ArgumentNullException(nameof(phoneWhatsapp)); // Garante que o número de WhatsApp não seja nulo
            Address = address ?? throw new ArgumentNullException(nameof(address)); // Garante que o endereço não seja nulo
            AvatarUrl = avatarUrl; // Pode ser nulo
            Notes = notes; // Pode ser nulo
        }
    }
}
