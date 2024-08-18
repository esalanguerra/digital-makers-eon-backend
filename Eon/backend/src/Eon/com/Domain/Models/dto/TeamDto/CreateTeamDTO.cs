using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.TeamDto
{
    /// <summary>
    /// DTO para a criação de um novo time.
    /// </summary>
    public class CreateTeamRequestDTO
    {
        /// <summary>
        /// Nome do time. Este campo é obrigatório.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição do time. Este campo é obrigatório.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identificador do setor associado ao time. Este campo é obrigatório.
        /// </summary>
        public int SectorId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do time.</param>
        /// <param name="description">Descrição do time.</param>
        /// <param name="sectorId">Identificador do setor associado ao time.</param>
        [JsonConstructor]
        public CreateTeamRequestDTO(
            string name, 
            string description, 
            int sectorId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            Description = description ?? throw new ArgumentNullException(nameof(description)); // Garante que a descrição não seja nula
            SectorId = sectorId; // Inicializa o ID do setor
        }
    }
}
