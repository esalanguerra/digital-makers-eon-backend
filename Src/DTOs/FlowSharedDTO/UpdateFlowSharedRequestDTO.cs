using System.Text.Json.Serialization;

namespace Eon.DTOs.FlowSharedDTO
{
    public class UpdateFlowSharedRequestDTO
    {
        // ID do fluxo (opcional)
        public int? FlowId { get; set; }

        // ID do usuário (opcional)
        public int? UserId { get; set; }

        // Link do fluxo compartilhado (opcional)
        public string? Link { get; set; }

        // Status do compartilhamento (opcional)
        public bool? Status { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateFlowSharedRequestDTO(int? flowId, int? userId, string? link, bool? status)
        {
            FlowId = flowId;
            UserId = userId;
            Link = link;
            Status = status;
        }
    }
}
