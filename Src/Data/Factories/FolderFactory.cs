using Eon.Data.Interfaces.IFactories;
using Eon.DTOs.FolderDTO;
using Eon.Data.Models.Folders;

namespace Eon.Data.Factories
{
    public class FolderFactory : IFolderFactoryInterface
    {
        public void ValidateCreateFolderRequest(CreateFolderRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Folder name is required.");
        }

        public void ValidateUpdateFolderRequest(UpdateFolderRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Folder name is required.");
        }

        public Folder CreateFolder(CreateFolderRequestDTO dto)
        {
            return new Folder(dto.Name);
        }

        public Folder UpdateFolder(Folder existingFolder, UpdateFolderRequestDTO dto)
        {
            existingFolder.Name = dto.Name;
            return existingFolder;
        }
    }
}
