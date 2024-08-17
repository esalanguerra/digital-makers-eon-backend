namespace Eon.Com.Api.ActionResults.ViewModels.UserViewModel
{
    public class UserViewModel
    {
        // Identificador único do usuário
        public int Id { get; set; }

        // Nome do usuário
        public string Name { get; set; }

        // E-mail do usuário
        public string Email { get; set; }

        // URL do avatar do usuário
        public string? AvatarUrl { get; set; }

        // Número de WhatsApp do usuário
        public string PhoneWhatsapp { get; set; }

        // Endereço do usuário
        public string Address { get; set; }

        // Notas adicionais sobre o usuário
        public string? Notes { get; set; }

        // Construtor padrão
        public UserViewModel()
        {
            // Inicialize as propriedades, se necessário
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            PhoneWhatsapp = string.Empty;
            Address = string.Empty;
        }

        // Construtor para inicializar o DTO com valores específicos
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
