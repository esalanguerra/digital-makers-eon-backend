namespace Eon.DTOs.FlowSharedDTO
{
    public class FlowSharedViewModelDTO
    {
        // Identificador único do fluxo compartilhado
        public int Id { get; set; }

        // ID do fluxo
        public int FlowId { get; set; }

        // ID do usuário
        public int UserId { get; set; }

        // Link do fluxo compartilhado
        public string Link { get; set; }

        // Status do compartilhamento
        public bool Status { get; set; }

        // Construtor padrão
        public FlowSharedViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public FlowSharedViewModelDTO(int id, int flowId, int userId, string link, bool status)
        {
            Id = id;
            FlowId = flowId;
            UserId = userId;
            Link = link;
            Status = status;
        }
    }
}
