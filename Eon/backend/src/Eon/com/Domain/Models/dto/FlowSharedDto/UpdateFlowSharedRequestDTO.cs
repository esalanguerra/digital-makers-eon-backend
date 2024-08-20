using System;
using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.FlowSharedDto
{
    /// <summary>
    /// DTO para a atualização das informações de um fluxo compartilhado.
    /// </summary>
    public class UpdateFlowSharedRequestDTO
    {
        /// <summary>
        /// Identificador do fluxo associado ao fluxo compartilhado. Este campo é opcional.
        /// </summary>
        public int? FlowId { get; set; }

        /// <summary>
        /// Identificador do usuário associado ao fluxo compartilhado. Este campo é opcional.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Link do fluxo compartilhado. Este campo é opcional.
        /// </summary>
        public string? Link { get; set; }

        /// <summary>
        /// Status do fluxo compartilhado. Este campo é opcional.
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="flowId">Identificador do fluxo.</param>
        /// <param name="userId">Identificador do usuário.</param>
        /// <param name="link">Link do fluxo compartilhado.</param>
        /// <param name="status">Status do fluxo compartilhado.</param>
        [JsonConstructor]
        public UpdateFlowSharedRequestDTO(
            int? flowId = null,
            int? userId = null,
            string? link = null,
            bool? status = null)
        {
            FlowId = flowId;
            UserId = userId;
            Link = link;
            Status = status;
        }
    }
}
