using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.TeamDto
{
    /// <summary>
    /// DTO para a atualização das informações de um time.
    /// </summary>
    public class UpdateTeamRequestDTO
    {
        /// <summary>
        /// Nome do time. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Descrição do time. Este campo é opcional.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Identificador do setor associado ao time. Este campo é opcional.
        /// </summary>
        public int? SectorId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do time.</param>
        /// <param name="description">Descrição do time.</param>
        /// <param name="sectorId">Identificador do setor associado ao time.</param>
        [JsonConstructor]
        public UpdateTeamRequestDTO(
            string? name = null, 
            string? description = null, 
            int? sectorId = null)
        {
            Name = name;
            Description = description;
            SectorId = sectorId;
        }
    }
}
