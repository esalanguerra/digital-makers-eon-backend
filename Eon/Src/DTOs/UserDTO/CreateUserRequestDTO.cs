using System.Text.Json.Serialization;

namespace Eon.DTOs.UserDTO
{
    public class CreateUserRequestDTO
    {
        // Nome do usuário
        public string Name { get; set; }

        // E-mail do usuário
        public string Email { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateUserRequestDTO(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
