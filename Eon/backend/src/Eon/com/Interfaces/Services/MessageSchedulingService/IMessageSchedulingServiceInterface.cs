using Eon.Com.Api.ActionResults.ApiResponseData.MessageSchedulingApiResponseData;
using Eon.Com.Domain.Models.Dto.MessageSchedulingDto;

namespace Eon.Com.Interfaces.Services.MessageSchedulingService
{
    public interface IMessageSchedulingServiceInterface
    {
        // Retorna uma coleção de mensagens agendadas encapsulada em um DTO com mensagem e código.
        // O DTO MessageSchedulingListResponse contém a lista de mensagens agendadas e informações adicionais, como mensagens de status.
        MessageSchedulingListResponse GetAll();

        // Retorna uma única mensagem agendada com base no ID.
        // O retorno é encapsulado em um DTO SingleMessageSchedulingResponse com mensagem e código de status.
        // Se a mensagem agendada não for encontrada, pode retornar nulo.
        SingleMessageSchedulingResponse? GetById(int id);

        // Retorna uma única mensagem agendada com base no nome.
        // O retorno é encapsulado em um DTO SingleMessageSchedulingResponse com mensagem e código de status.
        // Se a mensagem agendada não for encontrada, pode retornar nulo.
        SingleMessageSchedulingResponse? GetByName(string name);

        // Retorna uma única mensagem agendada com base no e-mail.
        // O retorno é encapsulado em um DTO SingleMessageSchedulingResponse com mensagem e código de status.
        // Se a mensagem agendada não for encontrada, pode retornar nulo.
        SingleMessageSchedulingResponse? GetByEmail(string email);

        // Cria uma nova mensagem agendada com base nos dados fornecidos no DTO CreateMessageSchedulingRequestDTO.
        // Retorna um DTO SingleMessageSchedulingResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleMessageSchedulingResponse? Save(CreateMessageSchedulingRequestDTO messageSchedulingDto);

        // Atualiza uma mensagem agendada existente com base no ID e nos dados fornecidos no DTO UpdateMessageSchedulingRequestDTO.
        // Retorna um DTO SingleMessageSchedulingResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleMessageSchedulingResponse? Update(int id, UpdateMessageSchedulingRequestDTO messageSchedulingDto);

        // Deleta uma mensagem agendada com base no ID.
        // Retorna um DTO SingleMessageSchedulingResponse com mensagem e código de status, indicando sucesso ou falha.
        // Se a mensagem agendada não for encontrada, pode retornar nulo.
        SingleMessageSchedulingResponse? Delete(int id);
    }
}
