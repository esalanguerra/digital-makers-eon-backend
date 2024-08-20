using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Interfaces.Repositories.SectorRepository
{
    public interface ISectorRepositoryInterface
    {
        // Obtém um setor pelo ID.
        // Retorna um objeto Sector ou null se não encontrado.
        Sector? GetById(int id);

        // Obtém um setor pelo nome.
        // Retorna um objeto Sector ou null se não encontrado.
        Sector? GetByName(string name);

        // Obtém todos os setores cadastrados.
        // Retorna uma coleção de objetos Sector.
        IEnumerable<Sector> GetAll();

        // Salva um novo setor no repositório.
        // Retorna o objeto Sector que foi salvo.
        Sector Add(Sector sector);

        // Atualiza um setor existente no repositório.
        // Retorna o objeto Sector atualizado.
        Sector Update(Sector sector);

        // Deleta um setor do repositório pelo ID.
        // Retorna o objeto Sector que foi deletado.
        Sector Delete(int id);
    }
}
