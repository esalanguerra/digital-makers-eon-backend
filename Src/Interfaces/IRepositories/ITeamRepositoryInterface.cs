using Eon.Data.Models.Teams;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface ITeamRepositoryInterface
    {
        // Obtém todos os times. Retorna uma coleção de times.
        IEnumerable<Team> GetAll();

        // Obtém um time pelo ID. Retorna um time ou null se não encontrado.
        Team? GetById(int id);

        // Obtém um time pelo nome. Retorna um time ou null se não encontrado.
        Team? GetByName(string name);

        // Salva um novo time no repositório. Retorna o time salvo.
        Team Save(Team team);

        // Atualiza um time existente pelo ID. Retorna o time atualizado.
        Team Update(int id, Team team);

        // Deleta um time pelo ID. Retorna o time deletado.
        Team Delete(int id);
    }
}
