using System.Text.Json.Serialization;

namespace Eon.DTOs.SectorDTO
{
    public class CreateSectorRequestDTO
    {
        // Equipe
        public string[] Team { get; set; }

        // Descrição do setor
        public string Description { get; set; }

        // ID do time
        public int TeamId { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateSectorRequestDTO(string[] team, string description, int teamId)
        {
            Team = team;
            Description = description;
            TeamId = teamId;
        }
    }
}
