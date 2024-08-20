using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.FlowDto
{
    /// <summary>
    /// DTO para a atualização das informações de um fluxo.
    /// </summary>
    public class UpdateFlowRequestDTO
    {
        /// <summary>
        /// Nome do fluxo. Este campo é opcional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Identificador da pasta associada ao fluxo. Este campo é opcional.
        /// </summary>
        public int? FolderId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do fluxo.</param>
        /// <param name="folderId">Identificador da pasta associada ao fluxo.</param>
        [JsonConstructor]
        public UpdateFlowRequestDTO(
            string? name = null, 
            int? folderId = null)
        {
            Name = name;
            FolderId = folderId;
        }
    }
}
