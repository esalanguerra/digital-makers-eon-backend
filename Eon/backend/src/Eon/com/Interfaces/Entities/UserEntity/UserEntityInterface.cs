namespace Eon.Com.Interfaces.Entities.UserEntity
{
    // Interface para entidade de usuário
    public interface UserEntityInterface
    {
        // Identificador único do usuário
        int Id { get; set; }

        // Nome do usuário
        string Name { get; set; }

        // E-mail do usuário
        string Email { get; set; }

        // URL do avatar do usuário
        string? AvatarUrl { get; set; }

        // Número de WhatsApp do usuário
        string PhoneWhatsapp { get; set; }

        // Endereço do usuário
        string Address { get; set; }

        // Notas adicionais sobre o usuário
        string? Notes { get; set; }
    }
}
