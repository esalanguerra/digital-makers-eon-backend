using Eon.Com.Api.ActionResults.ApiResponseData.FlowApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.FlowViewModel;
using Eon.Com.Domain.Models.Dto.FlowDto;
using Eon.Com.Interfaces.Controllers.FlowController;
using Eon.Com.Interfaces.Services.FlowService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.FlowMvc.Controller
{
    [ApiController]
    [Route("api/flows")]
    public class FlowController : ControllerBase, IFlowControllerInterface
    {
        private readonly IFlowServiceInterface _flowService;

        // Construtor que injeta o serviço de fluxo.
        // Recebe uma instância de IFlowServiceInterface que será usada para operações de CRUD.
        public FlowController(IFlowServiceInterface flowService)
        {
            _flowService = flowService ?? throw new ArgumentNullException(nameof(flowService));
        }

        /// <summary>
        /// Obtém todos os fluxos.
        /// Retorna uma resposta com uma lista de fluxos.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var flowListResponse = _flowService.GetAll();
            if (flowListResponse == null || !flowListResponse.Data.Any())
            {
                // Retorna uma resposta 404 se nenhum fluxo for encontrado.
                return NotFound(new FlowListResponse
                {
                    Message = "No flows found.",
                    Code = "404",
                    Data = new List<FlowViewModel>()
                });
            }

            return Ok(flowListResponse);
        }

        /// <summary>
        /// Obtém um fluxo pelo ID.
        /// Retorna uma resposta com os dados do fluxo ou uma mensagem de erro se o fluxo não for encontrado.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flowResponse = _flowService.GetById(id);

            if (flowResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo não for encontrado.
                return NotFound(new SingleFlowResponse
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(flowResponse);
        }

        /// <summary>
        /// Cria um novo fluxo com base nos dados fornecidos.
        /// Retorna uma resposta com os dados do fluxo criado ou uma mensagem de erro se a criação falhar.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateFlowRequestDTO flowDto)
        {
            if (flowDto == null)
            {
                // Retorna uma resposta 400 se os dados do fluxo não forem fornecidos.
                return BadRequest("Flow data is required.");
            }

            var createdFlowResponse = _flowService.Save(flowDto);

            if (createdFlowResponse == null)
            {
                // Retorna uma resposta 400 se a criação do fluxo falhar.
                return BadRequest(new SingleFlowResponse
                {
                    Message = "Flow could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 201 com a localização do novo fluxo.
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFlowResponse.Data?.Id },
                createdFlowResponse
            );
        }

        /// <summary>
        /// Atualiza um fluxo existente com base nos dados fornecidos.
        /// Retorna uma resposta 204 se a atualização for bem-sucedida ou uma mensagem de erro se a atualização falhar.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFlowRequestDTO flowDto)
        {
            if (flowDto == null)
            {
                // Retorna uma resposta 400 se os dados do fluxo não forem fornecidos.
                return BadRequest("Flow data is required.");
            }

            var existingFlowResponse = _flowService.GetById(id);

            if (existingFlowResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo não for encontrado.
                return NotFound(new SingleFlowResponse
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFlowResponse = _flowService.Update(id, flowDto);
            if (updatedFlowResponse == null)
            {
                // Retorna uma resposta 400 se a atualização falhar.
                return BadRequest(new SingleFlowResponse
                {
                    Message = "Flow could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 204 indicando que a atualização foi bem-sucedida.
            return NoContent();
        }

        /// <summary>
        /// Deleta um fluxo pelo ID.
        /// Retorna uma resposta 204 se a exclusão for bem-sucedida ou uma mensagem de erro se o fluxo não for encontrado.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var flowResponse = _flowService.GetById(id);

            if (flowResponse == null)
            {
                // Retorna uma resposta 404 se o fluxo não for encontrado.
                return NotFound(new SingleFlowResponse
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            _flowService.Delete(id);
            // Retorna uma resposta 204 indicando que a exclusão foi bem-sucedida.
            return NoContent();
        }
    }
}
