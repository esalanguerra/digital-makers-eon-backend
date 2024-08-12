using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.MessageSchedulingDTO;
using Eon.Data.Models.Messages;

namespace Eon.Api.Services.MessageSchedulingService
{
    public class MessageSchedulingService : IMessageSchedulingServiceInterface
    {
        private readonly IMessageSchedulingRepositoryInterface _messageSchedulingRepository;
        private readonly IMessageSchedulingFactoryInterface _messageSchedulingFactory;

        public MessageSchedulingService(IMessageSchedulingRepositoryInterface messageSchedulingRepository, IMessageSchedulingFactoryInterface messageSchedulingFactory)
        {
            _messageSchedulingRepository = messageSchedulingRepository;
            _messageSchedulingFactory = messageSchedulingFactory;
        }

        public MessageSchedulingListResponseDTO GetAll()
        {
            var messageSchedulings = _messageSchedulingRepository.GetAll();
            var messageSchedulingDtos = messageSchedulings.Select(ms => new MessageSchedulingViewModelDTO(ms.Id, ms.UserId, ms.Message, ms.ScheduledDate));
            return new MessageSchedulingListResponseDTO("Success", "200", messageSchedulingDtos);
        }

        public SingleMessageSchedulingResponseDTO? GetById(int id)
        {
            var messageScheduling = _messageSchedulingRepository.GetById(id);
            if (messageScheduling == null)
            {
                return new SingleMessageSchedulingResponseDTO("Message Scheduling not found", "404", null);
            }
            var messageSchedulingDto = new MessageSchedulingViewModelDTO(messageScheduling.Id, messageScheduling.UserId, messageScheduling.Message, messageScheduling.ScheduledDate);
            return new SingleMessageSchedulingResponseDTO("Success", "200", messageSchedulingDto);
        }

        public SingleMessageSchedulingResponseDTO Save(CreateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            _messageSchedulingFactory.ValidateCreateMessageSchedulingRequest(messageSchedulingDto);
            var messageScheduling = _messageSchedulingFactory.CreateMessageScheduling(messageSchedulingDto);
            var savedMessageScheduling = _messageSchedulingRepository.Save(messageScheduling);
            var responseDto = new MessageSchedulingViewModelDTO(savedMessageScheduling.Id, savedMessageScheduling.UserId, savedMessageScheduling.Message, savedMessageScheduling.ScheduledDate);
            return new SingleMessageSchedulingResponseDTO("Message Scheduling created successfully", "201", responseDto);
        }

        public SingleMessageSchedulingResponseDTO Update(int id, UpdateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            _messageSchedulingFactory.ValidateUpdateMessageSchedulingRequest(messageSchedulingDto);
            var existingMessageScheduling = _messageSchedulingRepository.GetById(id);
            if (existingMessageScheduling == null)
            {
                return new SingleMessageSchedulingResponseDTO("Message Scheduling not found", "404", null);
            }
            var updatedMessageScheduling = _messageSchedulingFactory.UpdateMessageScheduling(existingMessageScheduling, messageSchedulingDto);
            var savedMessageScheduling = _messageSchedulingRepository.Update(id, updatedMessageScheduling);
            var responseDto = new MessageSchedulingViewModelDTO(savedMessageScheduling.Id, savedMessageScheduling.UserId, savedMessageScheduling.Message, savedMessageScheduling.ScheduledDate);
            return new SingleMessageSchedulingResponseDTO("Message Scheduling updated successfully", "200", responseDto);
        }

        public SingleMessageSchedulingResponseDTO Delete(int id)
        {
            var deletedMessageScheduling = _messageSchedulingRepository.Delete(id);
            if (deletedMessageScheduling == null)
            {
                return new SingleMessageSchedulingResponseDTO("Message Scheduling not found", "404", null);
            }
            var responseDto = new MessageSchedulingViewModelDTO(deletedMessageScheduling.Id, deletedMessageScheduling.UserId, deletedMessageScheduling.Message, deletedMessageScheduling.ScheduledDate);
            return new SingleMessageSchedulingResponseDTO("Message Scheduling deleted successfully", "200", responseDto);
        }
    }
}
