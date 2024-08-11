using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.FolderDTO;
using Eon.Data.Models;
using Eon.Data.Interfaces.IRepositories;

namespace Eon.Api.Services.FolderService
{
    public class FolderService : IFolderServiceInterface
    {
        private readonly IFolderRepositoryInterface _folderRepository;
        private readonly IFolderFactoryInterface _folderFactory; // Atualizado para a interface

        public FolderService(IFolderRepositoryInterface folderRepository, IFolderFactoryInterface folderFactory)
        {
            _folderRepository = folderRepository;
            _folderFactory = folderFactory;
        }

        public FolderListResponseDTO GetAll()
        {
            var folders = _folderRepository.GetAll();
            return new FolderListResponseDTO
            {
                Message = "Success",
                Code = "200",
                Data = folders
            };
        }

        public SingleFolderResponseDTO? GetById(int id)
        {
            var folder = _folderRepository.GetById(id);

            if (folder == null)
            {
                return new SingleFolderResponseDTO
                {
                    Message = "Folder not found",
                    Code = "404",
                    Data = null
                };
            }

            return new SingleFolderResponseDTO
            {
                Message = "Folder found",
                Code = "200",
                Data = folder
            };
        }

        public SingleFolderResponseDTO Save(CreateFolderRequestDTO folderDto)
        {
            _folderFactory.ValidateCreateFolderRequest(folderDto);

            var folder = _folderFactory.CreateFolder(folderDto);
            return new SingleFolderResponseDTO
            {
                Message = "Folder created",
                Code = "201",
                Data = _folderRepository.Save(folder)
            };
        }

        public SingleFolderResponseDTO Update(int id, UpdateFolderRequestDTO folderDto)
        {
            var existingFolder = _folderRepository.GetById(id);
            if (existingFolder == null)
            {
                return new SingleFolderResponseDTO
                {
                    Message = "Folder not found",
                    Code = "404",
                    Data = null
                };
            }

            var updatedFolder = _folderFactory.UpdateFolder(existingFolder, folderDto);
            return new SingleFolderResponseDTO
            {
                Message = "Folder updated",
                Code = "200",
                Data = _folderRepository.Update(id, updatedFolder)
            };
        }

        public SingleFolderResponseDTO Delete(int id)
        {
            var folder = _folderRepository.GetById(id);
            if (folder == null)
            {
                return new SingleFolderResponseDTO
                {
                    Message = "Folder not found",
                    Code = "404",
                    Data = null
                };
            }

            return new SingleFolderResponseDTO
            {
                Message = "Folder deleted",
                Code = "200",
                Data = _folderRepository.Delete(id)
            };
        }
    }
}
