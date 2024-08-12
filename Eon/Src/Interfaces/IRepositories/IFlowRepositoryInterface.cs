using Eon.Data.Models.Flows;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface IFlowRepositoryInterface
    {
        // Obtém todos os fluxos. Retorna uma coleção de fluxos.
        IEnumerable<Flow> GetAll();

        // Obtém um fluxo pelo ID. Retorna um fluxo ou null se não encontrado.
        Flow? GetById(int id);

        // Obtém um fluxo pelo nome. Retorna um fluxo ou null se não encontrado.
        Flow? GetByName(string name);

        // Salva um novo fluxo no repositório. Retorna o fluxo salvo.
        Flow Save(Flow flow);

        // Atualiza um fluxo existente pelo ID. Retorna o fluxo atualizado.
        Flow Update(int id, Flow flow);

        // Deleta um fluxo pelo ID. Retorna o fluxo deletado.
        Flow Delete(int id);
    }
}
