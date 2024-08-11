using Eon.DTOs.MessageSchedulingDTO;
using Eon.Data.Models.Messages;

namespace Eon.Data.Interfaces.IFactories
{
    public interface IMessageSchedulingFactoryInterface
    {
        // Valida os dados fornecidos para criar uma nova mensagem agendada.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateMessageSchedulingRequest(CreateMessageSchedulingRequestDTO dto);

        // Valida os dados fornecidos para atualizar uma mensagem agendada existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateMessageSchedulingRequest(UpdateMessageSchedulingRequestDTO dto);

        // Cria e retorna um objeto MessageScheduling com base nos dados fornecidos no CreateMessageSchedulingRequestDTO.
        MessageScheduling CreateMessageScheduling(CreateMessageSchedulingRequestDTO dto);

        // Atualiza um objeto MessageScheduling existente com base nos dados fornecidos no UpdateMessageSchedulingRequestDTO.
        // Retorna o objeto MessageScheduling atualizado.
        MessageScheduling UpdateMessageScheduling(MessageScheduling existingMessageScheduling, UpdateMessageSchedulingRequestDTO dto);
    }
}
