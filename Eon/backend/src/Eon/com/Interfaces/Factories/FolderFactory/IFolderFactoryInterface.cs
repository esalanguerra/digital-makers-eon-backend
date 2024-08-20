using Eon.Com.Domain.Models.Dto.FolderDto;
using Eon.Com.Domain.Models.Entity.FolderEntity;

namespace Eon.Com.Interfaces.Factories.FolderFactory
{
    public interface IFolderFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para a criação de uma nova pasta.
        /// Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        /// </summary>
        void ValidateCreateFolderRequest(CreateFolderRequestDTO dto);

        /// <summary>
        /// Valida os dados fornecidos para a atualização de uma pasta existente.
        /// Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        /// </summary>
        void ValidateUpdateFolderRequest(UpdateFolderRequestDTO dto);

        /// <summary>
        /// Cria uma nova pasta com base nos dados fornecidos no CreateFolderRequestDTO.
        /// </summary>
        /// <param name="dto">Dados da nova pasta.</param>
        /// <returns>Objeto Folder criado.</returns>
        Folder CreateFolder(CreateFolderRequestDTO dto);

        /// <summary>
        /// Atualiza uma pasta existente com base nos dados fornecidos no UpdateFolderRequestDTO.
        /// </summary>
        /// <param name="existingFolder">Pasta existente a ser atualizada.</param>
        /// <param name="dto">Dados de atualização da pasta.</param>
        /// <returns>Pasta atualizada.</returns>
        Folder UpdateFolder(Folder existingFolder, UpdateFolderRequestDTO dto);
    }
}
