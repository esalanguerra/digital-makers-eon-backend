using Eon.Com.Api.ActionResults.ApiResponseData.FolderApiResponseData;
using Eon.Com.Domain.Models.Dto.FolderDto;

namespace Eon.Com.Interfaces.Services.FolderService
{
    public interface IFolderServiceInterface
    {
        /// <summary>
        /// Retorna uma coleção de pastas encapsulada em um DTO com mensagem e código.
        /// O DTO FolderListResponse contém a lista de pastas e informações adicionais, como mensagens de status.
        /// </summary>
        FolderListResponse GetAll();

        /// <summary>
        /// Retorna uma única pasta com base no ID.
        /// O retorno é encapsulado em um DTO SingleFolderResponse com mensagem e código de status.
        /// Se a pasta não for encontrada, pode retornar nulo.
        /// </summary>
        SingleFolderResponse? GetById(int id);

        /// <summary>
        /// Retorna uma única pasta com base no nome.
        /// O retorno é encapsulado em um DTO SingleFolderResponse com mensagem e código de status.
        /// Se a pasta não for encontrada, pode retornar nulo.
        /// </summary>
        SingleFolderResponse? GetByName(string name);

        /// <summary>
        /// Cria uma nova pasta com base nos dados fornecidos no DTO CreateFolderRequestDTO.
        /// Retorna um DTO SingleFolderResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFolderResponse? Save(CreateFolderRequestDTO folderDto);

        /// <summary>
        /// Atualiza uma pasta existente com base no ID e nos dados fornecidos no DTO UpdateFolderRequestDTO.
        /// Retorna um DTO SingleFolderResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFolderResponse? Update(int id, UpdateFolderRequestDTO folderDto);

        /// <summary>
        /// Deleta uma pasta com base no ID.
        /// Retorna um DTO SingleFolderResponse com mensagem e código de status, indicando sucesso ou falha.
        /// Se a pasta não for encontrada, pode retornar nulo.
        /// </summary>
        SingleFolderResponse? Delete(int id);
    }
}
