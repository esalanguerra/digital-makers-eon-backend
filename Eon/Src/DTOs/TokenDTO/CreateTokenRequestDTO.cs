using System.Text.Json.Serialization;

namespace Eon.DTOs.TokenDTO
{
    public class CreateTokenRequestDTO
    {
        // Valor do token
        public string Value { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateTokenRequestDTO(string value)
        {
            Value = value;
        }
    }
}
