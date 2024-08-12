using Eon.DTOs.FolderDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface IFolderServiceInterface
    {
        // Retorna uma coleção de pastas encapsulada em um DTO com mensagem e código
        FolderListResponseDTO GetAll();

        // Retorna uma pasta única com base no ID encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleFolderResponseDTO? GetById(int id);

        // Retorna uma pasta única com base no nome encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleFolderResponseDTO? GetByName(string name);

        // Cria uma nova pasta com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleFolderResponseDTO? Save(CreateFolderRequestDTO folderDto);

        // Atualiza uma pasta existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleFolderResponseDTO? Update(int id, UpdateFolderRequestDTO folderDto);

        // Deleta uma pasta com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleFolderResponseDTO? Delete(int id);
    }
}
