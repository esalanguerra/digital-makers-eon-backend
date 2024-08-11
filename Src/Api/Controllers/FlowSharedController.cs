using Eon.DTOs.FlowSharedDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/flow-shareds")]
    public class FlowSharedController : ControllerBase, IFlowSharedControllerInterface
    {
        private readonly IFlowSharedServiceInterface _flowSharedService;

        public FlowSharedController(IFlowSharedServiceInterface flowSharedService)
        {
            _flowSharedService = flowSharedService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var flowSharedListResponse = _flowSharedService.GetAll();
            if (flowSharedListResponse == null || !flowSharedListResponse.Data.Any())
            {
                return NotFound(new FlowSharedListResponseDTO
                {
                    Message = "No flow shareds found.",
                    Code = "404",
                    Data = new List<FlowSharedViewModelDTO>()
                });
            }

            return Ok(flowSharedListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flowSharedResponse = _flowSharedService.GetById(id);

            if (flowSharedResponse == null)
            {
                return NotFound(new SingleFlowSharedResponseDTO
                {
                    Message = "Flow shared not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(flowSharedResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateFlowSharedRequestDTO flowSharedDto)
        {
            if (flowSharedDto == null)
            {
                return BadRequest("Flow shared data is required.");
            }

            var createdFlowSharedResponse = _flowSharedService.Save(flowSharedDto);

            if (createdFlowSharedResponse == null)
            {
                return BadRequest(new SingleFlowSharedResponseDTO
                {
                    Message = "Flow shared could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFlowSharedResponse.Data?.Id },
                createdFlowSharedResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFlowSharedRequestDTO flowSharedDto)
        {
            if (flowSharedDto == null)
            {
                return BadRequest("Flow shared data is required.");
            }

            var existingFlowSharedResponse = _flowSharedService.GetById(id);

            if (existingFlowSharedResponse == null)
            {
                return NotFound(new SingleFlowSharedResponseDTO
                {
                    Message = "Flow shared not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFlowSharedResponse = _flowSharedService.Update(id, flowSharedDto);
            if (updatedFlowSharedResponse == null)
            {
                return BadRequest(new SingleFlowSharedResponseDTO
                {
                    Message = "Flow shared could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var flowSharedResponse = _flowSharedService.GetById(id);

            if (flowSharedResponse == null)
            {
                return NotFound(new SingleFlowSharedResponseDTO
                {
                    Message = "Flow shared not found.",
                    Code = "404",
                    Data = null
                });
            }

            _flowSharedService.Delete(id);
            return NoContent();
        }
    }
}
