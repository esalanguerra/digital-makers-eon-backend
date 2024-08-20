using Eon.Com.Api.ActionResults.ApiResponseData.FolderApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FolderViewModel;
using Eon.Com.Domain.Models.Dto.FolderDto;
using Eon.Com.Interfaces.Factories.FolderFactory;
using Eon.Com.Interfaces.Repositories.FolderRepository;
using Eon.Com.Interfaces.Services.FolderService;

namespace Eon.Com.Api.Mvc.FolderMvc.Service
{
    public class FolderService : IFolderServiceInterface
    {
        private readonly IFolderRepositoryInterface _folderRepository;
        private readonly IFolderFactoryInterface _folderFactory;

        // Construtor que injeta as dependências necessárias
        public FolderService(IFolderRepositoryInterface folderRepository, IFolderFactoryInterface folderFactory)
        {
            _folderRepository = folderRepository;
            _folderFactory = folderFactory;
        }

        /// <summary>
        /// Obtém todos os setores e retorna uma resposta com uma lista de setores.
        /// </summary>
        public FolderListResponse GetAll()
        {
            var folders = _folderRepository.GetAll();
            var folderDtos = folders.Select(folder => new FolderViewModel(
                folder.Id,
                folder.Name,
                folder.SectorId
            )).ToList(); // Convert to List for better performance in case of large datasets
            
            return new FolderListResponse("Success", "200", folderDtos);
        }

        /// <summary>
        /// Obtém uma pasta pelo ID e retorna uma resposta com os dados da pasta.
        /// </summary>
        public SingleFolderResponse? GetById(int id)
        {
            var folder = _folderRepository.GetById(id);
            if (folder == null)
            {
                return new SingleFolderResponse("Folder not found", "404", null);
            }

            var folderDto = new FolderViewModel(
                folder.Id,
                folder.Name,
                folder.SectorId
            );

            return new SingleFolderResponse("Success", "200", folderDto);
        }

        /// <summary>
        /// Obtém uma pasta pelo nome e retorna uma resposta com os dados da pasta.
        /// </summary>
        public SingleFolderResponse GetByName(string name)
        {
            var folder = _folderRepository.GetByName(name);
            if (folder == null)
            {
                return new SingleFolderResponse("Folder not found", "404", null);
            }

            var folderDto = new FolderViewModel(
                folder.Id,
                folder.Name,
                folder.SectorId
            );

            return new SingleFolderResponse("Success", "200", folderDto);
        }

        /// <summary>
        /// Cria uma nova pasta com base nos dados fornecidos e retorna uma resposta com a pasta criada.
        /// </summary>
        public SingleFolderResponse Save(CreateFolderRequestDTO folderDto)
        {
            // Valida os dados da pasta usando FolderFactory
            _folderFactory.ValidateCreateFolderRequest(folderDto);

            // Cria uma nova pasta a partir do DTO
            var folder = _folderFactory.CreateFolder(folderDto);

            // Salva a pasta no repositório
            var savedFolder = _folderRepository.Add(folder);

            // Cria e retorna a resposta
            var responseDto = new FolderViewModel(
                savedFolder.Id,
                savedFolder.Name,
                savedFolder.SectorId
            );
            
            return new SingleFolderResponse("Folder created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza uma pasta existente com base nos dados fornecidos e retorna uma resposta com a pasta atualizada.
        /// </summary>
        public SingleFolderResponse Update(int id, UpdateFolderRequestDTO folderDto)
        {
            // Valida os dados da pasta usando FolderFactory
            _folderFactory.ValidateUpdateFolderRequest(folderDto);

            // Recupera a pasta existente
            var existingFolder = _folderRepository.GetById(id);
            if (existingFolder == null)
            {
                return new SingleFolderResponse("Folder not found", "404", null);
            }

            // Atualiza a pasta com os dados do DTO
            var updatedFolder = _folderFactory.UpdateFolder(existingFolder, folderDto);

            // Salva a pasta atualizada no repositório
            var savedFolder = _folderRepository.Update(updatedFolder);

            // Cria e retorna a resposta
            var responseDto = new FolderViewModel(
                savedFolder.Id,
                savedFolder.Name,
                savedFolder.SectorId
            );
            
            return new SingleFolderResponse("Folder updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta uma pasta pelo ID e retorna uma resposta com a pasta deletada.
        /// </summary>
        public SingleFolderResponse Delete(int id)
        {
            // Deleta a pasta do repositório
            var deletedFolder = _folderRepository.Delete(id);
            if (deletedFolder == null)
            {
                return new SingleFolderResponse("Folder not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new FolderViewModel(
                deletedFolder.Id,
                deletedFolder.Name,
                deletedFolder.SectorId
            );

            return new SingleFolderResponse("Folder deleted successfully", "200", responseDto);
        }
    }
}
