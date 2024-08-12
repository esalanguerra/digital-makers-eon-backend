using Eon.DTOs.MessageSchedulingDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Messages;

namespace Eon.Data.Factories
{
    public class MessageSchedulingFactory : IMessageSchedulingFactoryInterface
    {
        public void ValidateCreateMessageSchedulingRequest(CreateMessageSchedulingRequestDTO dto)
        {
            ValidateCreateMessageScheduling(dto);
        }

        public void ValidateUpdateMessageSchedulingRequest(UpdateMessageSchedulingRequestDTO dto)
        {
            ValidateUpdateMessageScheduling(dto);
        }

        private void ValidateCreateMessageScheduling(CreateMessageSchedulingRequestDTO dto)
        {
            if (dto.UserId <= 0)
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrEmpty(dto.MessageText))
                throw new ArgumentException("Message is required.");

            if (dto.SendDate == default)
                throw new ArgumentException("ScheduledDate is required.");
        }

        private void ValidateUpdateMessageScheduling(UpdateMessageSchedulingRequestDTO dto)
        {
            if (dto.UserId <= 0)
                throw new ArgumentException("UserId is required.");

            if (string.IsNullOrEmpty(dto.MessageText))
                throw new ArgumentException("Message is required.");

            if (dto.SendDate == default)
                throw new ArgumentException("ScheduledDate is required.");
        }

        public MessageScheduling CreateMessageScheduling(CreateMessageSchedulingRequestDTO dto)
        {
            return new MessageScheduling
            {
                UserId = dto.UserId,
                MessageText = dto.MessageText,
                SendDate = dto.SendDate
            };
        }

        public MessageScheduling UpdateMessageScheduling(MessageScheduling existingMessageScheduling, UpdateMessageSchedulingRequestDTO dto)
        {
            existingMessageScheduling.UserId = dto.UserId;
            existingMessageScheduling.MessageText = dto.MessageText;
            existingMessageScheduling.SendDate = (DateTime)dto.SendDate;
            return existingMessageScheduling;
        }
    }
}
