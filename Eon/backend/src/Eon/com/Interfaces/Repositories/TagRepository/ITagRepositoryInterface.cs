using Eon.Com.Domain.Models.Entity.TagEntity;

namespace Eon.Com.Interfaces.Repositories.TagRepository
{
    public interface ITagRepositoryInterface
    {
        // Obtém uma etiqueta pelo ID.
        // Retorna um objeto Tag ou null se não encontrado.
        Tag? GetById(int id);

        // Obtém uma etiqueta pelo nome.
        // Retorna um objeto Tag ou null se não encontrado.
        Tag? GetByName(string name);

        // Obtém todas as etiquetas cadastradas.
        // Retorna uma coleção de objetos Tag.
        IEnumerable<Tag> GetAll();

        // Salva uma nova etiqueta no repositório.
        // Retorna o objeto Tag que foi salvo.
        Tag Add(Tag tag);

        // Atualiza uma etiqueta existente no repositório.
        // Retorna o objeto Tag atualizado.
        Tag Update(Tag tag);

        // Deleta uma etiqueta do repositório pelo ID.
        // Retorna o objeto Tag que foi deletado.
        Tag Delete(int id);
    }
}
