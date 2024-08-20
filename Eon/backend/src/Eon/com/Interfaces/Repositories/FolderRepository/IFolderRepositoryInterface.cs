using Eon.Com.Domain.Models.Entity.FolderEntity;

namespace Eon.Com.Interfaces.Repositories.FolderRepository
{
    public interface IFolderRepositoryInterface
    {
        /// <summary>
        /// Obtém uma pasta pelo nome.
        /// Retorna um objeto Folder ou null se não encontrado.
        /// </summary>
        Folder? GetByName(string name);

        /// <summary>
        /// Obtém uma pasta pelo ID.
        /// Retorna um objeto Folder ou null se não encontrado.
        /// </summary>
        Folder? GetById(int id);

        /// <summary>
        /// Obtém todas as pastas cadastradas.
        /// Retorna uma coleção de objetos Folder.
        /// </summary>
        IEnumerable<Folder> GetAll();

        /// <summary>
        /// Salva uma nova pasta no repositório.
        /// Retorna o objeto Folder que foi salvo.
        /// </summary>
        Folder Add(Folder folder);

        /// <summary>
        /// Atualiza uma pasta existente no repositório.
        /// Retorna o objeto Folder atualizado.
        /// </summary>
        Folder Update(Folder folder);

        /// <summary>
        /// Deleta uma pasta do repositório pelo ID.
        /// Retorna o objeto Folder que foi deletado.
        /// </summary>
        Folder Delete(int id);
    }
}
