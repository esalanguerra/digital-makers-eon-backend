using System.Text.Json.Serialization;

namespace Eon.DTOs.TokenDTO
{
    public class UpdateTokenRequestDTO
    {
        // Valor do token (opcional)
        public string? Value { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateTokenRequestDTO(string? value)
        {
            Value = value;
        }
    }
}
