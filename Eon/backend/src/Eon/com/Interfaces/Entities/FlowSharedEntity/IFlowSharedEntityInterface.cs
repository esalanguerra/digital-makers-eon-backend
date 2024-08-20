namespace Eon.Com.Interfaces.Entities.FlowSharedEntity
{
    // Interface para definir a estrutura da entidade FlowShared.
    public interface IFlowSharedEntityInterface
    {
        // Identificador único do fluxo compartilhado.
        // Deve ser um valor único para cada fluxo compartilhado e geralmente é gerado automaticamente.
        int Id { get; set; }

        // Identificador do fluxo.
        // Representa o ID do fluxo associado ao fluxo compartilhado.
        int FlowId { get; set; }

        // Identificador do usuário.
        // Representa o ID do usuário associado ao fluxo compartilhado.
        int UserId { get; set; }

        // Link do fluxo compartilhado.
        // Utilizado para armazenar o link relacionado ao fluxo compartilhado.
        string Link { get; set; }

        // Status do fluxo compartilhado.
        // Opcional. Indica se o fluxo compartilhado está ativo ou não.
        bool Status { get; set; }
    }
}
