using Eon.DTOs.FolderDTO;
using Eon.Data.Models.Folders;

namespace Eon.Data.Interfaces.IFactories
{
    public interface IFolderFactoryInterface
    {
        // Valida os dados fornecidos para criar uma nova pasta.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateFolderRequest(CreateFolderRequestDTO dto);

        // Valida os dados fornecidos para atualizar uma pasta existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateFolderRequest(UpdateFolderRequestDTO dto);

        // Cria e retorna um objeto Folder com base nos dados fornecidos no CreateFolderRequestDTO.
        Folder CreateFolder(CreateFolderRequestDTO dto);

        // Atualiza um objeto Folder existente com base nos dados fornecidos no UpdateFolderRequestDTO.
        // Retorna o objeto Folder atualizado.
        Folder UpdateFolder(Folder existingFolder, UpdateFolderRequestDTO dto);
    }
}
