using System;
using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.FolderDto
{
    /// <summary>
    /// DTO para a atualização das informações de uma pasta.
    /// </summary>
    public class UpdateFolderRequestDTO
    {
        /// <summary>
        /// Nome da pasta. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Identificador do setor associado à pasta. Este campo é opcional.
        /// </summary>
        public int? SectorId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome da pasta.</param>
        /// <param name="sectorId">Identificador do setor.</param>
        [JsonConstructor]
        public UpdateFolderRequestDTO(
            string? name = null, 
            int? sectorId = null)
        {
            Name = name;
            SectorId = sectorId;
        }
    }
}
