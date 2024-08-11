using Eon.Data.Models.Sectors;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface ISectorRepositoryInterface
    {
        // Obtém todos os setores. Retorna uma coleção de setores.
        IEnumerable<Sector> GetAll();

        // Obtém um setor pelo ID. Retorna um setor ou null se não encontrado.
        Sector? GetById(int id);

        // Obtém todos os setores pertencentes a um time específico. Retorna uma coleção de setores.
        IEnumerable<Sector> GetByTeamId(int teamId);

        // Salva um novo setor no repositório. Retorna o setor salvo.
        Sector Save(Sector sector);

        // Atualiza um setor existente pelo ID. Retorna o setor atualizado.
        Sector Update(int id, Sector sector);

        // Deleta um setor pelo ID. Retorna o setor deletado.
        Sector Delete(int id);
    }
}
