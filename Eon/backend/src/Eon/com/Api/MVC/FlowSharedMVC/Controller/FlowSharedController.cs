using Eon.Com.Api.ActionResults.ApiResponseData.FlowSharedApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FlowSharedViewModel;
using Eon.Com.Domain.Models.Dto.FlowSharedDto;
using Eon.Com.Interfaces.Controllers.FlowSharedController;
using Eon.Com.Interfaces.Services.FlowSharedService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.FlowSharedMvc.Controller
{
    [ApiController]
    [Route("api/flows-shared")]
    public class FlowSharedController : ControllerBase, IFlowSharedControllerInterface
    {
        private readonly IFlowSharedServiceInterface _flowSharedService;

        // Construtor que injeta o serviço de fluxos compartilhados.
        public FlowSharedController(IFlowSharedServiceInterface flowSharedService)
        {
            _flowSharedService = flowSharedService ?? throw new ArgumentNullException(nameof(flowSharedService));
        }

        /// <summary>
        /// Obtém todos os fluxos compartilhados.
        /// Retorna uma resposta com uma lista de fluxos compartilhados.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var flowSharedListResponse = _flowSharedService.GetAll();
            if (flowSharedListResponse == null || !flowSharedListResponse.Data.Any())
            {
                // Retorna uma resposta 404 se nenhum fluxo compartilhado for encontrado.
                return NotFound(new FlowSharedListResponse
                {
                    Message = "No flows shared found.",
                    Code = "404",
                    Data = new List<FlowSharedViewModel>()
                });
            }

            return Ok(flowSharedListResponse);
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo ID.
        /// Retorna uma resposta com os dados do fluxo compartilhado ou uma mensagem de erro se o fluxo compartilhado não for encontrado.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flowSharedResponse = _flowSharedService.GetById(id);

            if (flowSharedResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo compartilhado não for encontrado.
                return NotFound(new SingleFlowSharedResponse
                {
                    Message = "FlowShared not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(flowSharedResponse);
        }

        /// <summary>
        /// Obtém um fluxo compartilhado pelo link.
        /// Retorna uma resposta com os dados do fluxo compartilhado ou uma mensagem de erro se o fluxo compartilhado não for encontrado.
        /// </summary>
        [HttpGet("link/{link}")]
        public IActionResult GetByLink(string link)
        {
            var flowSharedResponse = _flowSharedService.GetByLink(link);

            if (flowSharedResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo compartilhado não for encontrado.
                return NotFound(new SingleFlowSharedResponse
                {
                    Message = "FlowShared not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(flowSharedResponse);
        }

        /// <summary>
        /// Cria um novo fluxo compartilhado com base nos dados fornecidos.
        /// Retorna uma resposta com os dados do fluxo compartilhado criado ou uma mensagem de erro se a criação falhar.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateFlowSharedRequestDTO flowSharedDto)
        {
            if (flowSharedDto == null)
            {
                // Retorna uma resposta 400 se os dados do fluxo compartilhado não forem fornecidos.
                return BadRequest("FlowShared data is required.");
            }

            var createdFlowSharedResponse = _flowSharedService.Save(flowSharedDto);

            if (createdFlowSharedResponse == null)
            {
                // Retorna uma resposta 400 se a criação do fluxo compartilhado falhar.
                return BadRequest(new SingleFlowSharedResponse
                {
                    Message = "FlowShared could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 201 com a localização do novo fluxo compartilhado.
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFlowSharedResponse.Data?.FlowId },
                createdFlowSharedResponse
            );
        }

        /// <summary>
        /// Atualiza um fluxo compartilhado existente com base nos dados fornecidos.
        /// Retorna uma resposta 204 se a atualização for bem-sucedida ou uma mensagem de erro se a atualização falhar.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFlowSharedRequestDTO flowSharedDto)
        {
            if (flowSharedDto == null)
            {
                // Retorna uma resposta 400 se os dados do fluxo compartilhado não forem fornecidos.
                return BadRequest("FlowShared data is required.");
            }

            var existingFlowSharedResponse = _flowSharedService.GetById(id);

            if (existingFlowSharedResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo compartilhado não for encontrado.
                return NotFound(new SingleFlowSharedResponse
                {
                    Message = "FlowShared not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFlowSharedResponse = _flowSharedService.Update(id, flowSharedDto);
            if (updatedFlowSharedResponse == null)
            {
                // Retorna uma resposta 400 se a atualização falhar.
                return BadRequest(new SingleFlowSharedResponse
                {
                    Message = "FlowShared could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 204 indicando que a atualização foi bem-sucedida.
            return NoContent();
        }

        /// <summary>
        /// Deleta um fluxo compartilhado pelo ID.
        /// Retorna uma resposta 204 se a exclusão for bem-sucedida ou uma mensagem de erro se o fluxo compartilhado não for encontrado.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var flowSharedResponse = _flowSharedService.GetById(id);

            if (flowSharedResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo compartilhado não for encontrado.
                return NotFound(new SingleFlowSharedResponse
                {
                    Message = "FlowShared not found.",
                    Code = "404",
                    Data = null
                });
            }

            _flowSharedService.Delete(id);
            // Retorna uma resposta 204 indicando que a exclusão foi bem-sucedida.
            return NoContent();
        }
    }
}
