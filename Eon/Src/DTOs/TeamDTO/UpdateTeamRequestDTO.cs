using System.Text.Json.Serialization;

namespace Eon.DTOs.TeamDTO
{
    public class UpdateTeamRequestDTO
    {
        // Nome do time (opcional)
        public string? Name { get; set; }

        // Descrição do time (opcional)
        public string? Description { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateTeamRequestDTO(string? name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
