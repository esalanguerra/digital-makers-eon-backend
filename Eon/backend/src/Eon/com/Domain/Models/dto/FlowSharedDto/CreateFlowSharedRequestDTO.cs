using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.FlowSharedDto
{
    /// <summary>
    /// DTO para a criação de um novo fluxo compartilhado.
    /// </summary>
    public class CreateFlowSharedRequestDTO
    {
        /// <summary>
        /// Identificador do fluxo associado ao fluxo compartilhado. Este campo é obrigatório.
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// Identificador do usuário associado ao fluxo compartilhado. Este campo é obrigatório.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Link do fluxo compartilhado. Este campo é obrigatório.
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Status do fluxo compartilhado. Este campo é opcional.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="flowId">Identificador do fluxo.</param>
        /// <param name="userId">Identificador do usuário.</param>
        /// <param name="link">Link do fluxo compartilhado.</param>
        /// <param name="status">Status do fluxo compartilhado.</param>
        [JsonConstructor]
        public CreateFlowSharedRequestDTO(
            int flowId,
            int userId,
            string link,
            bool status)
        {
            FlowId = flowId; // Inicializa o ID do fluxo
            UserId = userId; // Inicializa o ID do usuário
            Link = link ?? throw new ArgumentNullException(nameof(link)); // Garante que o link não seja nulo
            Status = status; // Inicializa o status
        }
    }
}
