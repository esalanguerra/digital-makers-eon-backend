using System.Text.Json.Serialization;

namespace Eon.DTOs.TeamDTO
{
    public class CreateTeamRequestDTO
    {
        // Nome do time
        public string Name { get; set; }

        // Descrição do time
        public string Description { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateTeamRequestDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
