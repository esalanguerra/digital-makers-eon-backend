using System.Text.Json.Serialization;

namespace Eon.DTOs.FlowSharedDTO
{
    public class CreateFlowSharedRequestDTO
    {
        // ID do fluxo
        public int FlowId { get; set; }

        // ID do usuário
        public int UserId { get; set; }

        // Link do fluxo compartilhado
        public string Link { get; set; }

        // Status do compartilhamento
        public bool Status { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateFlowSharedRequestDTO(int flowId, int userId, string link, bool status)
        {
            FlowId = flowId;
            UserId = userId;
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Status = status;
        }
    }
}
