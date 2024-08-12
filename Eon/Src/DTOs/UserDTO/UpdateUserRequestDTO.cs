using System.Text.Json.Serialization;

namespace Eon.DTOs.UserDTO
{
    public class UpdateUserRequestDTO
    {
        // Nome do usuário (opcional)
        public string? Name { get; set; }

        // E-mail do usuário (opcional)
        public string? Email { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateUserRequestDTO(string? name, string? email)
        {
            Name = name;
            Email = email;
        }
    }
}
