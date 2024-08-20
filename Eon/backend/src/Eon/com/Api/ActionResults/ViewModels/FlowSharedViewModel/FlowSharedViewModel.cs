using Eon.Com.Domain.Models.Entity.FlowSharedEntity;

namespace Eon.Com.Api.ActionResults.ViewModels.FlowSharedViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados de fluxos compartilhados na API.
    /// </summary>
    public class FlowSharedViewModel
    {
        // Identificador único do fluxo compartilhado
        public int Id { get; }

        // Identificador do fluxo associado ao fluxo compartilhado
        public int FlowId { get; }

        // Identificador do usuário associado ao fluxo compartilhado
        public int UserId { get; }

        // Link do fluxo compartilhado
        public string Link { get; }

        // Status do fluxo compartilhado
        public bool Status { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public FlowSharedViewModel()
        {
            Id = 0;
            FlowId = 0;
            UserId = 0;
            Link = string.Empty;
            Status = false;
        }

        /// <summary>
        /// Construtor para inicializar o ViewModel com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do fluxo compartilhado.</param>
        /// <param name="flowId">Identificador do fluxo associado.</param>
        /// <param name="userId">Identificador do usuário associado.</param>
        /// <param name="link">Link do fluxo compartilhado.</param>
        /// <param name="status">Status do fluxo compartilhado.</param>
        public FlowSharedViewModel(int id, int flowId, int userId, string link, bool status)
        {
            Id = id;
            FlowId = flowId;
            UserId = userId;
            Link = link;
            Status = status;
        }
    }
}
