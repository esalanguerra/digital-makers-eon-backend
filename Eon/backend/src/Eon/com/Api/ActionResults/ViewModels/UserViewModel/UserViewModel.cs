namespace Eon.Com.Api.ActionResults.ViewModels.UserViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados do usuário na API.
    /// </summary>
    public class UserViewModel
    {
        // Identificador único do usuário
        public int Id { get; }
        
        // Nome do usuário
        public string Name { get; }
        
        // E-mail do usuário
        public string Email { get; }
        
        // URL do avatar do usuário (opcional)
        public string? AvatarUrl { get; }
        
        // Número de WhatsApp do usuário
        public string PhoneWhatsapp { get; }
        
        // Endereço do usuário
        public string Address { get; }
        
        // Notas adicionais sobre o usuário (opcional)
        public string? Notes { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public UserViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            PhoneWhatsapp = string.Empty;
            Address = string.Empty;
            AvatarUrl = null;  // Inicializa com null, se não for obrigatório
            Notes = null;      // Inicializa com null, se não for obrigatório
        }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <param name="name">Nome do usuário.</param>
        /// <param name="email">E-mail do usuário.</param>
        /// <param name="phoneWhatsapp">Número de WhatsApp do usuário.</param>
        /// <param name="address">Endereço do usuário.</param>
        /// <param name="avatarUrl">URL do avatar do usuário (opcional).</param>
        /// <param name="notes">Notas adicionais sobre o usuário (opcional).</param>
        public UserViewModel(int id, string name, string email, string phoneWhatsapp, string address, string? avatarUrl = null, string? notes = null)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneWhatsapp = phoneWhatsapp;
            Address = address;
            AvatarUrl = avatarUrl;
            Notes = notes;
        }
    }
}
