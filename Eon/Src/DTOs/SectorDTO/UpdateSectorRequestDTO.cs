using System.Text.Json.Serialization;

namespace Eon.DTOs.SectorDTO
{
    public class UpdateSectorRequestDTO
    {
        // Equipe (opcional)
        public string[]? Team { get; set; }

        // Descrição do setor (opcional)
        public string? Description { get; set; }

        // ID do time (opcional)
        public int? TeamId { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateSectorRequestDTO(string[]? team, string? description, int? teamId)
        {
            Team = team;
            Description = description;
            TeamId = teamId;
        }
    }
}
