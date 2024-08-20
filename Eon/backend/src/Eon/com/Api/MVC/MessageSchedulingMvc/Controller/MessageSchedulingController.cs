using Eon.Com.Api.ActionResults.ApiResponseData.MessageSchedulingApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.MessageSchedulingViewModel;
using Eon.Com.Domain.Models.Dto.MessageSchedulingDto;
using Eon.Com.Interfaces.Controllers.MessageSchedulingController;
using Eon.Com.Interfaces.Services.MessageSchedulingService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.MessageSchedulingMvc.Controller
{
    [ApiController]
    [Route("api/messagescheduling")]
    public class MessageSchedulingController : ControllerBase, IMessageSchedulingControllerInterface
    {
        private readonly IMessageSchedulingServiceInterface _messageSchedulingService;

        // Construtor que injeta o serviço de agendamento de mensagens.
        // Recebe uma instância de IMessageSchedulingServiceInterface que será usada para operações de CRUD.
        public MessageSchedulingController(IMessageSchedulingServiceInterface messageSchedulingService)
        {
            _messageSchedulingService = messageSchedulingService ?? throw new ArgumentNullException(nameof(messageSchedulingService));
        }

        /// <summary>
        /// Obtém todas as mensagens agendadas.
        /// Retorna uma resposta com uma lista de mensagens agendadas.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var messageSchedulingListResponse = _messageSchedulingService.GetAll();
            if (messageSchedulingListResponse == null || !messageSchedulingListResponse.Data.Any())
            {
                // Retorna uma resposta 404 se nenhuma mensagem agendada for encontrada.
                return NotFound(new MessageSchedulingListResponse
                {
                    Message = "No scheduled messages found.",
                    Code = "404",
                    Data = new List<MessageSchedulingViewModel>()
                });
            }

            return Ok(messageSchedulingListResponse);
        }

        /// <summary>
        /// Obtém uma mensagem agendada pelo ID.
        /// Retorna uma resposta com os dados da mensagem ou uma mensagem de erro se a mensagem não for encontrada.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var messageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (messageSchedulingResponse == null)
            {
                // Retorna uma resposta 404 se a mensagem agendada não for encontrada.
                return NotFound(new SingleMessageSchedulingResponse
                {
                    Message = "Scheduled message not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(messageSchedulingResponse);
        }

        /// <summary>
        /// Cria uma nova mensagem agendada com base nos dados fornecidos.
        /// Retorna uma resposta com os dados da mensagem criada ou uma mensagem de erro se a criação falhar.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            if (messageSchedulingDto == null)
            {
                // Retorna uma resposta 400 se os dados da mensagem não forem fornecidos.
                return BadRequest("Message scheduling data is required.");
            }

            var createdMessageSchedulingResponse = _messageSchedulingService.Save(messageSchedulingDto);

            if (createdMessageSchedulingResponse == null)
            {
                // Retorna uma resposta 400 se a criação da mensagem agendada falhar.
                return BadRequest(new SingleMessageSchedulingResponse
                {
                    Message = "Scheduled message could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 201 com a localização da nova mensagem agendada.
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdMessageSchedulingResponse.Data?.Id },
                createdMessageSchedulingResponse
            );
        }

        /// <summary>
        /// Atualiza uma mensagem agendada existente com base nos dados fornecidos.
        /// Retorna uma resposta 204 se a atualização for bem-sucedida ou uma mensagem de erro se a atualização falhar.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            if (messageSchedulingDto == null)
            {
                // Retorna uma resposta 400 se os dados da mensagem não forem fornecidos.
                return BadRequest("Message scheduling data is required.");
            }

            var existingMessageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (existingMessageSchedulingResponse == null)
            {
                // Retorna uma resposta 404 se a mensagem agendada não for encontrada.
                return NotFound(new SingleMessageSchedulingResponse
                {
                    Message = "Scheduled message not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedMessageSchedulingResponse = _messageSchedulingService.Update(id, messageSchedulingDto);
            if (updatedMessageSchedulingResponse == null)
            {
                // Retorna uma resposta 400 se a atualização falhar.
                return BadRequest(new SingleMessageSchedulingResponse
                {
                    Message = "Scheduled message could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 204 indicando que a atualização foi bem-sucedida.
            return NoContent();
        }

        /// <summary>
        /// Deleta uma mensagem agendada pelo ID.
        /// Retorna uma resposta 204 se a exclusão for bem-sucedida ou uma mensagem de erro se a mensagem não for encontrada.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var messageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (messageSchedulingResponse == null)
            {
                // Retorna uma resposta 404 se a mensagem agendada não for encontrada.
                return NotFound(new SingleMessageSchedulingResponse
                {
                    Message = "Scheduled message not found.",
                    Code = "404",
                    Data = null
                });
            }

            _messageSchedulingService.Delete(id);
            // Retorna uma resposta 204 indicando que a exclusão foi bem-sucedida.
            return NoContent();
        }
    }
}
