using Eon.Data.Models.Tags;

namespace Eon.Data.Interfaces.IRepositories
{
    public interface ITagRepositoryInterface
    {
        // Obtém todas as tags. Retorna uma coleção de tags.
        IEnumerable<Tag> GetAll();

        // Obtém uma tag pelo ID. Retorna uma tag ou null se não encontrada.
        Tag? GetById(int id);

        // Obtém uma tag pelo nome. Retorna uma tag ou null se não encontrada.
        Tag? GetByName(string name);

        // Salva uma nova tag no repositório. Retorna a tag salva.
        Tag Save(Tag tag);

        // Atualiza uma tag existente pelo ID. Retorna a tag atualizada.
        Tag Update(int id, Tag tag);

        // Deleta uma tag pelo ID. Retorna a tag deletada.
        Tag Delete(int id);
    }
}
