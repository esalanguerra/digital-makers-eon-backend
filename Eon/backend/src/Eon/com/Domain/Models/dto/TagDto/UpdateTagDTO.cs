using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.TagDto
{
    /// <summary>
    /// DTO para a atualização das informações de uma etiqueta.
    /// </summary>
    public class UpdateTagRequestDTO
    {
        /// <summary>
        /// Nome da etiqueta. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Descrição da etiqueta. Este campo é opcional.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Identificador do setor associado à etiqueta. Este campo é opcional.
        /// </summary>
        public int? SectorId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome da etiqueta.</param>
        /// <param name="description">Descrição da etiqueta.</param>
        /// <param name="sectorId">Identificador do setor associado à etiqueta.</param>
        [JsonConstructor]
        public UpdateTagRequestDTO(
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
