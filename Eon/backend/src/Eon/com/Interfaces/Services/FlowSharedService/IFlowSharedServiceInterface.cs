using Eon.Com.Api.ActionResults.ApiResponseData.FlowSharedApiResponseData;
using Eon.Com.Domain.Models.Dto.FlowSharedDto;

namespace Eon.Com.Interfaces.Services.FlowSharedService
{
    public interface IFlowSharedServiceInterface
    {
        /// <summary>
        /// Retorna uma coleção de fluxos compartilhados encapsulada em um DTO com mensagem e código.
        /// O DTO FlowSharedListResponse contém a lista de fluxos compartilhados e informações adicionais, como mensagens de status.
        /// </summary>
        FlowSharedListResponse GetAll();

        /// <summary>
        /// Retorna um único fluxo compartilhado com base no ID.
        /// O retorno é encapsulado em um DTO SingleFlowSharedResponse com mensagem e código de status.
        /// Se o fluxo compartilhado não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowSharedResponse? GetById(int id);

        /// <summary>
        /// Retorna um único fluxo compartilhado com base no link.
        /// O retorno é encapsulado em um DTO SingleFlowSharedResponse com mensagem e código de status.
        /// Se o fluxo compartilhado não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowSharedResponse? GetByLink(string link);

        /// <summary>
        /// Cria um novo fluxo compartilhado com base nos dados fornecidos no DTO CreateFlowSharedRequestDTO.
        /// Retorna um DTO SingleFlowSharedResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFlowSharedResponse? Save(CreateFlowSharedRequestDTO flowSharedDto);

        /// <summary>
        /// Atualiza um fluxo compartilhado existente com base no ID e nos dados fornecidos no DTO UpdateFlowSharedRequestDTO.
        /// Retorna um DTO SingleFlowSharedResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFlowSharedResponse? Update(int id, UpdateFlowSharedRequestDTO flowSharedDto);

        /// <summary>
        /// Deleta um fluxo compartilhado com base no ID.
        /// Retorna um DTO SingleFlowSharedResponse com mensagem e código de status, indicando sucesso ou falha.
        /// Se o fluxo compartilhado não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowSharedResponse? Delete(int id);
    }
}
