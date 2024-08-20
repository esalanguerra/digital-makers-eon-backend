using Eon.Com.Domain.Models.Dto.MessageSchedulingDto; // Supondo que os DTOs para mensagem agendada estejam neste namespace
using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity; // Supondo que a entidade para mensagem agendada esteja neste namespace

namespace Eon.Com.Interfaces.Factories.MessageSchedulingFactory
{
    public interface IMessageSchedulingFactoryInterface
    {
        // Valida os dados fornecidos para a criação de uma nova mensagem agendada.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateMessageSchedulingRequest(CreateMessageSchedulingRequestDTO dto);

        // Valida os dados fornecidos para a atualização de uma mensagem agendada existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateMessageSchedulingRequest(UpdateMessageSchedulingRequestDTO dto);

        // Cria um novo objeto MessageScheduling com base nos dados fornecidos no CreateMessageSchedulingRequestDTO.
        // Retorna o objeto MessageScheduling criado.
        MessageScheduling CreateMessageScheduling(CreateMessageSchedulingRequestDTO dto);

        // Atualiza um objeto MessageScheduling existente com base nos dados fornecidos no UpdateMessageSchedulingRequestDTO.
        // Retorna o objeto MessageScheduling atualizado.
        MessageScheduling UpdateMessageScheduling(MessageScheduling existingMessageScheduling, UpdateMessageSchedulingRequestDTO dto);
    }
}
