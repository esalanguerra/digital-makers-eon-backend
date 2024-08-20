using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.TagDto
{
    /// <summary>
    /// DTO para a criação de uma nova etiqueta.
    /// </summary>
    public class CreateTagRequestDTO
    {
        /// <summary>
        /// Nome da etiqueta. Este campo é obrigatório.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição da etiqueta. Este campo é obrigatório.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identificador do setor associado à etiqueta. Este campo é obrigatório.
        /// </summary>
        public int SectorId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome da etiqueta.</param>
        /// <param name="description">Descrição da etiqueta.</param>
        /// <param name="sectorId">Identificador do setor associado à etiqueta.</param>
        [JsonConstructor]
        public CreateTagRequestDTO(
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
