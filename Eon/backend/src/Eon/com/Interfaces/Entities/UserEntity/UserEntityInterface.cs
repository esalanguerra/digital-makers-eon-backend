namespace Eon.Com.Interfaces.Entities.UserEntity
{
    // Interface para definir a estrutura da entidade de usuário.
    public interface UserEntityInterface
    {
        // Identificador único do usuário.
        // Deve ser um valor único para cada usuário e geralmente é gerado automaticamente.
        int Id { get; set; }

        // Nome do usuário.
        // Representa o nome completo ou o nome pelo qual o usuário é conhecido.
        string Name { get; set; }

        // E-mail do usuário.
        // Utilizado para comunicação e autenticação do usuário.
        string Email { get; set; }

        // URL do avatar do usuário.
        // Opcional. Utilizado para armazenar a URL da imagem de perfil do usuário.
        string? AvatarUrl { get; set; }

        // Número de WhatsApp do usuário.
        // Usado para contato via WhatsApp. Pode conter apenas números e alguns caracteres especiais.
        string PhoneWhatsapp { get; set; }

        // Endereço do usuário.
        // Pode incluir rua, número, bairro, cidade e estado. Utilizado para correspondência e localização.
        string Address { get; set; }

        // Notas adicionais sobre o usuário.
        // Opcional. Pode conter informações adicionais ou comentários sobre o usuário.
        string? Notes { get; set; }
    }
}
