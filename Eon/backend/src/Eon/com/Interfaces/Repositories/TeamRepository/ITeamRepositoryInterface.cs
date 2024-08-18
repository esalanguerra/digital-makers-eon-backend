using Eon.Com.Domain.Models.Entity.TeamEntity;

namespace Eon.Com.Interfaces.Repositories.TeamRepository
{
    public interface ITeamRepositoryInterface
    {
        // Obtém um time pelo ID.
        // Retorna um objeto Team ou null se não encontrado.
        Team? GetById(int id);

        // Obtém um time pelo nome.
        // Retorna um objeto Team ou null se não encontrado.
        Team? GetByName(string name);

        // Obtém todos os times cadastrados.
        // Retorna uma coleção de objetos Team.
        IEnumerable<Team> GetAll();

        // Salva um novo time no repositório.
        // Retorna o objeto Team que foi salvo.
        Team Add(Team team);

        // Atualiza um time existente no repositório.
        // Retorna o objeto Team atualizado.
        Team Update(Team team);

        // Deleta um time do repositório pelo ID.
        // Retorna o objeto Team que foi deletado.
        Team Delete(int id);
    }
}
