using Eon.Com.Domain.Models.Entity.FlowSharedEntity;

namespace Eon.Com.Interfaces.Repositories.FlowSharedRepository
{
    public interface IFlowSharedRepositoryInterface
    {
        /// <summary>
        /// Obtém um fluxo compartilhado pelo link.
        /// Retorna um objeto FlowShared ou null se não encontrado.
        /// </summary>
        FlowShared? GetByLink(string link);

        /// <summary>
        /// Obtém um fluxo compartilhado pelo ID.
        /// Retorna um objeto FlowShared ou null se não encontrado.
        /// </summary>
        FlowShared? GetById(int id);

        /// <summary>
        /// Obtém todos os fluxos compartilhados cadastrados.
        /// Retorna uma coleção de objetos FlowShared.
        /// </summary>
        IEnumerable<FlowShared> GetAll();

        /// <summary>
        /// Salva um novo fluxo compartilhado no repositório.
        /// Retorna o objeto FlowShared que foi salvo.
        /// </summary>
        FlowShared Add(FlowShared flowShared);

        /// <summary>
        /// Atualiza um fluxo compartilhado existente no repositório.
        /// Retorna o objeto FlowShared atualizado.
        /// </summary>
        FlowShared Update(FlowShared flowShared);

        /// <summary>
        /// Deleta um fluxo compartilhado do repositório pelo ID.
        /// Retorna o objeto FlowShared que foi deletado.
        /// </summary>
        FlowShared Delete(int id);
    }
}
