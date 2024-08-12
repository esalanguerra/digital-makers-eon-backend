using Eon.DTOs.MessageSchedulingDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface IMessageSchedulingServiceInterface
    {
        // Retorna uma coleção de mensagens agendadas encapsulada em um DTO com mensagem e código
        MessageSchedulingListResponseDTO GetAll();

        // Retorna uma mensagem agendada única com base no ID encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleMessageSchedulingResponseDTO? GetById(int id);

        // Retorna uma mensagem agendada única com base no ID do usuário encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleMessageSchedulingResponseDTO? GetByUserId(int userId);

        // Retorna uma mensagem agendada única com base no número de WhatsApp encapsulada em um DTO com mensagem e código, ou nulo se não encontrado
        SingleMessageSchedulingResponseDTO? GetByWhatsAppNumber(string whatsAppNumber);

        // Cria uma nova mensagem agendada com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleMessageSchedulingResponseDTO? Save(CreateMessageSchedulingRequestDTO messageSchedulingDto);

        // Atualiza uma mensagem agendada existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleMessageSchedulingResponseDTO? Update(int id, UpdateMessageSchedulingRequestDTO messageSchedulingDto);

        // Deleta uma mensagem agendada com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleMessageSchedulingResponseDTO? Delete(int id);
    }
}
