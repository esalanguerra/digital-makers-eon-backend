using Eon.Data.Models.Flows;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface IFlowSharedRepositoryInterface
    {
        // Obtém todos os fluxos compartilhados. Retorna uma coleção de fluxos compartilhados.
        IEnumerable<FlowShared> GetAll();

        // Obtém um fluxo compartilhado pelo ID. Retorna um fluxo compartilhado ou null se não encontrado.
        FlowShared? GetById(int id);

        // Obtém todos os fluxos compartilhados de um usuário específico. Retorna uma coleção de fluxos compartilhados.
        IEnumerable<FlowShared> GetByUserId(int userId);

        // Obtém todos os fluxos compartilhados para um fluxo específico. Retorna uma coleção de fluxos compartilhados.
        IEnumerable<FlowShared> GetByFlowId(int flowId);

        // Salva um novo fluxo compartilhado no repositório. Retorna o fluxo compartilhado salvo.
        FlowShared Save(FlowShared flowShared);

        // Atualiza um fluxo compartilhado existente pelo ID. Retorna o fluxo compartilhado atualizado.
        FlowShared Update(int id, FlowShared flowShared);

        // Deleta um fluxo compartilhado pelo ID. Retorna o fluxo compartilhado deletado.
        FlowShared Delete(int id);
    }
}
