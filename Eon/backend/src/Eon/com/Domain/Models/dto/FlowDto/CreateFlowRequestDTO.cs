using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.FlowDto
{
    /// <summary>
    /// DTO para a criação de um novo fluxo.
    /// </summary>
    public class CreateFlowRequestDTO
    {
        /// <summary>
        /// Nome do fluxo. Este campo é obrigatório.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Identificador da pasta associada ao fluxo. Este campo é obrigatório.
        /// </summary>
        public int FolderId { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="name">Nome do fluxo.</param>
        /// <param name="folderId">Identificador da pasta associada ao fluxo.</param>
        [JsonConstructor]
        public CreateFlowRequestDTO(
            string name, 
            int folderId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Garante que o nome não seja nulo
            FolderId = folderId; // Inicializa o ID da pasta associada
        }
    }
}
