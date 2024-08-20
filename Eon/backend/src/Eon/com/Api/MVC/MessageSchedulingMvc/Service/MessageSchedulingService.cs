using Eon.Com.Api.ActionResults.ApiResponseData.MessageSchedulingApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.MessageSchedulingViewModel;
using Eon.Com.Domain.Models.Dto.MessageSchedulingDto;
using Eon.Com.Interfaces.Factories.MessageSchedulingFactory;
using Eon.Com.Interfaces.Repositories.MessageSchedulingRepository;
using Eon.Com.Interfaces.Services.MessageSchedulingService;
using System;
using System.Linq;

namespace Eon.Com.Api.Mvc.MessageSchedulingMvc.Service
{
    public class MessageSchedulingService : IMessageSchedulingServiceInterface
    {
        private readonly IMessageSchedulingRepositoryInterface _messageSchedulingRepository;
        private readonly IMessageSchedulingFactoryInterface _messageSchedulingFactory;

        // Construtor que injeta as dependências necessárias
        public MessageSchedulingService(IMessageSchedulingRepositoryInterface messageSchedulingRepository, IMessageSchedulingFactoryInterface messageSchedulingFactory)
        {
            _messageSchedulingRepository = messageSchedulingRepository ?? throw new ArgumentNullException(nameof(messageSchedulingRepository));
            _messageSchedulingFactory = messageSchedulingFactory ?? throw new ArgumentNullException(nameof(messageSchedulingFactory));
        }

        /// <summary>
        /// Obtém todas as mensagens agendadas e retorna uma resposta com uma lista de mensagens.
        /// </summary>
        public MessageSchedulingListResponse GetAll()
        {
            var messageSchedulings = _messageSchedulingRepository.GetAll();
            var messageSchedulingDtos = messageSchedulings.Select(messageScheduling => new MessageSchedulingViewModel(
                messageScheduling.Id,
                messageScheduling.MessageText,
                messageScheduling.TagId,
                messageScheduling.UserId,
                messageScheduling.FlowId,
                messageScheduling.SendDate,
                messageScheduling.WhatsAppNumber,
                messageScheduling.Status
            )).ToList();

            return new MessageSchedulingListResponse("Success", "200", messageSchedulingDtos);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo ID e retorna uma resposta com os dados da mensagem.
        /// </summary>
        public SingleMessageSchedulingResponse? GetById(int id)
        {
            var messageScheduling = _messageSchedulingRepository.GetById(id);
            if (messageScheduling == null)
            {
                return new SingleMessageSchedulingResponse("Message scheduling not found", "404", null);
            }

            var messageSchedulingDto = new MessageSchedulingViewModel(
                messageScheduling.Id,
                messageScheduling.MessageText,
                messageScheduling.TagId,
                messageScheduling.UserId,
                messageScheduling.FlowId,
                messageScheduling.SendDate,
                messageScheduling.WhatsAppNumber,
                messageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Success", "200", messageSchedulingDto);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo nome e retorna uma resposta com os dados da mensagem.
        /// </summary>
        public SingleMessageSchedulingResponse? GetByName(string name)
        {
            var messageScheduling = _messageSchedulingRepository.GetByName(name); // Adapte o método de repositório conforme necessário
            if (messageScheduling == null)
            {
                return new SingleMessageSchedulingResponse("Message scheduling not found", "404", null);
            }

            var messageSchedulingDto = new MessageSchedulingViewModel(
                messageScheduling.Id,
                messageScheduling.MessageText,
                messageScheduling.TagId,
                messageScheduling.UserId,
                messageScheduling.FlowId,
                messageScheduling.SendDate,
                messageScheduling.WhatsAppNumber,
                messageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Success", "200", messageSchedulingDto);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo e-mail e retorna uma resposta com os dados da mensagem.
        /// </summary>
        public SingleMessageSchedulingResponse? GetByEmail(string email)
        {
            var messageScheduling = _messageSchedulingRepository.GetByEmail(email); // Adapte o método de repositório conforme necessário
            if (messageScheduling == null)
            {
                return new SingleMessageSchedulingResponse("Message scheduling not found", "404", null);
            }

            var messageSchedulingDto = new MessageSchedulingViewModel(
                messageScheduling.Id,
                messageScheduling.MessageText,
                messageScheduling.TagId,
                messageScheduling.UserId,
                messageScheduling.FlowId,
                messageScheduling.SendDate,
                messageScheduling.WhatsAppNumber,
                messageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Success", "200", messageSchedulingDto);
        }


        /// <summary>
        /// Cria uma nova mensagem agendada com base nos dados fornecidos e retorna uma resposta com a mensagem criada.
        /// </summary>
        public SingleMessageSchedulingResponse Save(CreateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            // Valida os dados da mensagem agendada usando MessageSchedulingFactory
            _messageSchedulingFactory.ValidateCreateMessageSchedulingRequest(messageSchedulingDto);

            // Cria uma nova mensagem agendada a partir do DTO
            var messageScheduling = _messageSchedulingFactory.CreateMessageScheduling(messageSchedulingDto);

            // Salva a mensagem agendada no repositório
            var savedMessageScheduling = _messageSchedulingRepository.Add(messageScheduling);

            // Cria e retorna a resposta
            var responseDto = new MessageSchedulingViewModel(
                savedMessageScheduling.Id,
                savedMessageScheduling.MessageText,
                savedMessageScheduling.TagId,
                savedMessageScheduling.UserId,
                savedMessageScheduling.FlowId,
                savedMessageScheduling.SendDate,
                savedMessageScheduling.WhatsAppNumber,
                savedMessageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Message scheduling created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza uma mensagem agendada existente com base nos dados fornecidos e retorna uma resposta com a mensagem atualizada.
        /// </summary>
        public SingleMessageSchedulingResponse Update(int id, UpdateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            // Valida os dados da mensagem agendada usando MessageSchedulingFactory
            _messageSchedulingFactory.ValidateUpdateMessageSchedulingRequest(messageSchedulingDto);

            // Recupera a mensagem agendada existente
            var existingMessageScheduling = _messageSchedulingRepository.GetById(id);
            if (existingMessageScheduling == null)
            {
                return new SingleMessageSchedulingResponse("Message scheduling not found", "404", null);
            }

            // Atualiza a mensagem agendada com os dados do DTO
            var updatedMessageScheduling = _messageSchedulingFactory.UpdateMessageScheduling(existingMessageScheduling, messageSchedulingDto);

            // Salva a mensagem agendada atualizada no repositório
            var savedMessageScheduling = _messageSchedulingRepository.Update(updatedMessageScheduling);

            // Cria e retorna a resposta
            var responseDto = new MessageSchedulingViewModel(
                savedMessageScheduling.Id,
                savedMessageScheduling.MessageText,
                savedMessageScheduling.TagId,
                savedMessageScheduling.UserId,
                savedMessageScheduling.FlowId,
                savedMessageScheduling.SendDate,
                savedMessageScheduling.WhatsAppNumber,
                savedMessageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Message scheduling updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta uma mensagem agendada pelo ID e retorna uma resposta com a mensagem deletada.
        /// </summary>
        public SingleMessageSchedulingResponse Delete(int id)
        {
            // Deleta a mensagem agendada do repositório
            var deletedMessageScheduling = _messageSchedulingRepository.Delete(id);
            if (deletedMessageScheduling == null)
            {
                return new SingleMessageSchedulingResponse("Message scheduling not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new MessageSchedulingViewModel(
                deletedMessageScheduling.Id,
                deletedMessageScheduling.MessageText,
                deletedMessageScheduling.TagId,
                deletedMessageScheduling.UserId,
                deletedMessageScheduling.FlowId,
                deletedMessageScheduling.SendDate,
                deletedMessageScheduling.WhatsAppNumber,
                deletedMessageScheduling.Status
            );

            return new SingleMessageSchedulingResponse("Message scheduling deleted successfully", "200", responseDto);
        }
    }
}
