using Eon.Com.Domain.Models.Entity.FlowEntity;

namespace Eon.Com.Interfaces.Repositories.FlowRepository
{
    public interface IFlowRepositoryInterface
    {
        /// <summary>
        /// Obtém um fluxo pelo nome.
        /// Retorna um objeto Flow ou null se não encontrado.
        /// </summary>
        Flow? GetByName(string name);

        /// <summary>
        /// Obtém um fluxo pelo ID.
        /// Retorna um objeto Flow ou null se não encontrado.
        /// </summary>
        Flow? GetById(int id);

        /// <summary>
        /// Obtém todos os fluxos cadastrados.
        /// Retorna uma coleção de objetos Flow.
        /// </summary>
        IEnumerable<Flow> GetAll();

        /// <summary>
        /// Salva um novo fluxo no repositório.
        /// Retorna o objeto Flow que foi salvo.
        /// </summary>
        Flow Add(Flow flow);

        /// <summary>
        /// Atualiza um fluxo existente no repositório.
        /// Retorna o objeto Flow atualizado.
        /// </summary>
        Flow Update(Flow flow);

        /// <summary>
        /// Deleta um fluxo do repositório pelo ID.
        /// Retorna o objeto Flow que foi deletado.
        /// </summary>
        Flow Delete(int id);
    }
}
