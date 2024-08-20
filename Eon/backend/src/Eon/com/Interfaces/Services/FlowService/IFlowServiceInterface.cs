using Eon.Com.Api.ActionResults.ApiResponseData.FlowApiResponseData;
using Eon.Com.Domain.Models.Dto.FlowDto;

namespace Eon.Com.Interfaces.Services.FlowService
{
    public interface IFlowServiceInterface
    {
        /// <summary>
        /// Retorna uma coleção de fluxos encapsulada em um DTO com mensagem e código.
        /// O DTO FlowListResponse contém a lista de fluxos e informações adicionais, como mensagens de status.
        /// </summary>
        FlowListResponse GetAll();

        /// <summary>
        /// Retorna um único fluxo com base no ID.
        /// O retorno é encapsulado em um DTO SingleFlowResponse com mensagem e código de status.
        /// Se o fluxo não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowResponse? GetById(int id);

        /// <summary>
        /// Retorna um único fluxo com base no nome.
        /// O retorno é encapsulado em um DTO SingleFlowResponse com mensagem e código de status.
        /// Se o fluxo não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowResponse GetByName(string name);

        /// <summary>
        /// Cria um novo fluxo com base nos dados fornecidos no DTO CreateFlowRequestDTO.
        /// Retorna um DTO SingleFlowResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFlowResponse? Save(CreateFlowRequestDTO flowDto);

        /// <summary>
        /// Atualiza um fluxo existente com base no ID e nos dados fornecidos no DTO UpdateFlowRequestDTO.
        /// Retorna um DTO SingleFlowResponse com mensagem e código de status, indicando sucesso ou falha.
        /// </summary>
        SingleFlowResponse? Update(int id, UpdateFlowRequestDTO flowDto);

        /// <summary>
        /// Deleta um fluxo com base no ID.
        /// Retorna um DTO SingleFlowResponse com mensagem e código de status, indicando sucesso ou falha.
        /// Se o fluxo não for encontrado, pode retornar nulo.
        /// </summary>
        SingleFlowResponse? Delete(int id);
    }
}
