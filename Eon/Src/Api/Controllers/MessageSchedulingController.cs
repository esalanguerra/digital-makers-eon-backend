using Eon.DTOs.MessageSchedulingDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/message-schedulings")]
    public class MessageSchedulingController : ControllerBase, IMessageSchedulingControllerInterface
    {
        private readonly IMessageSchedulingServiceInterface _messageSchedulingService;

        public MessageSchedulingController(IMessageSchedulingServiceInterface messageSchedulingService)
        {
            _messageSchedulingService = messageSchedulingService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var messageSchedulingListResponse = _messageSchedulingService.GetAll();
            if (messageSchedulingListResponse == null || !messageSchedulingListResponse.Data.Any())
            {
                return NotFound(new MessageSchedulingListResponseDTO
                {
                    Message = "No message schedulings found.",
                    Code = "404",
                    Data = new List<MessageSchedulingViewModelDTO>()
                });
            }

            return Ok(messageSchedulingListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var messageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (messageSchedulingResponse == null)
            {
                return NotFound(new SingleMessageSchedulingResponseDTO
                {
                    Message = "Message scheduling not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(messageSchedulingResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            if (messageSchedulingDto == null)
            {
                return BadRequest("Message scheduling data is required.");
            }

            var createdMessageSchedulingResponse = _messageSchedulingService.Save(messageSchedulingDto);

            if (createdMessageSchedulingResponse == null)
            {
                return BadRequest(new SingleMessageSchedulingResponseDTO
                {
                    Message = "Message scheduling could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdMessageSchedulingResponse.Data?.Id },
                createdMessageSchedulingResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateMessageSchedulingRequestDTO messageSchedulingDto)
        {
            if (messageSchedulingDto == null)
            {
                return BadRequest("Message scheduling data is required.");
            }

            var existingMessageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (existingMessageSchedulingResponse == null)
            {
                return NotFound(new SingleMessageSchedulingResponseDTO
                {
                    Message = "Message scheduling not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedMessageSchedulingResponse = _messageSchedulingService.Update(id, messageSchedulingDto);
            if (updatedMessageSchedulingResponse == null)
            {
                return BadRequest(new SingleMessageSchedulingResponseDTO
                {
                    Message = "Message scheduling could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var messageSchedulingResponse = _messageSchedulingService.GetById(id);

            if (messageSchedulingResponse == null)
            {
                return NotFound(new SingleMessageSchedulingResponseDTO
                {
                    Message = "Message scheduling not found.",
                    Code = "404",
                    Data = null
                });
            }

            _messageSchedulingService.Delete(id);
            return NoContent();
        }
    }
}
