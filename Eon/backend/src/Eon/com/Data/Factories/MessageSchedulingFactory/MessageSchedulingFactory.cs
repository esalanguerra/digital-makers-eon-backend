using Eon.Com.Domain.Models.Dto.MessageSchedulingDto; // Supondo que os DTOs para mensagens agendadas estejam neste namespace
using Eon.Com.Domain.Models.Entity.MessageSchedulingEntity; // Supondo que a entidade MessageScheduling esteja neste namespace
using Eon.Com.Interfaces.Factories.MessageSchedulingFactory; // Atualize o namespace conforme necessário

namespace Eon.Com.Data.Factories.MessageSchedulingFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de mensagens agendadas.
    /// </summary>
    public class MessageSchedulingFactory : IMessageSchedulingFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar uma nova mensagem agendada.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a mensagem agendada.</param>
        public void ValidateCreateMessageSchedulingRequest(CreateMessageSchedulingRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateMessageScheduling(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar uma mensagem agendada existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar a mensagem agendada.</param>
        public void ValidateUpdateMessageSchedulingRequest(UpdateMessageSchedulingRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateMessageScheduling(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateMessageSchedulingRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateMessageScheduling(CreateMessageSchedulingRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.MessageText))
                throw new ArgumentException("Message text is required.", nameof(dto.MessageText)); // Valida que o texto da mensagem não seja nulo ou em branco

            // Adicione outras validações conforme necessário
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateMessageSchedulingRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateMessageScheduling(UpdateMessageSchedulingRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto MessageScheduling a partir do CreateMessageSchedulingRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar a mensagem agendada.</param>
        /// <returns>Um objeto MessageScheduling criado a partir do DTO.</returns>
        public MessageScheduling CreateMessageScheduling(CreateMessageSchedulingRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new MessageScheduling
            {
                MessageText = dto.MessageText,
                TagId = dto.TagId,
                UserId = dto.UserId,
                FlowId = dto.FlowId,
                SendDate = dto.SendDate,
                WhatsAppNumber = dto.WhatsAppNumber,
                Status = dto.Status
                // Inicialize outras propriedades conforme necessário
            };
        }

        /// <summary>
        /// Atualiza um objeto MessageScheduling existente com base no UpdateMessageSchedulingRequestDTO.
        /// </summary>
        /// <param name="existingMessageScheduling">A mensagem agendada existente a ser atualizada.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto MessageScheduling atualizado.</returns>
        public MessageScheduling UpdateMessageScheduling(MessageScheduling existingMessageScheduling, UpdateMessageSchedulingRequestDTO dto)
        {
            if (existingMessageScheduling == null) throw new ArgumentNullException(nameof(existingMessageScheduling)); // Garante que a mensagem agendada não seja nula
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades da mensagem agendada com base nos valores não nulos do DTO
            existingMessageScheduling.MessageText = string.IsNullOrEmpty(dto.MessageText) ? existingMessageScheduling.MessageText : dto.MessageText;
            existingMessageScheduling.TagId = dto.TagId ?? existingMessageScheduling.TagId;
            existingMessageScheduling.UserId = dto.UserId ?? existingMessageScheduling.UserId;
            existingMessageScheduling.FlowId = dto.FlowId ?? existingMessageScheduling.FlowId;
            existingMessageScheduling.SendDate = dto.SendDate ?? existingMessageScheduling.SendDate;
            existingMessageScheduling.WhatsAppNumber = string.IsNullOrEmpty(dto.WhatsAppNumber) ? existingMessageScheduling.WhatsAppNumber : dto.WhatsAppNumber;
            existingMessageScheduling.Status = string.IsNullOrEmpty(dto.Status) ? existingMessageScheduling.Status : dto.Status;

            return existingMessageScheduling;
        }
    }
}
