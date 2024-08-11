using Eon.DTOs.FlowDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/flows")]
    public class FlowController : ControllerBase, IFlowControllerInterface
    {
        private readonly IFlowServiceInterface _flowService;

        // Constructor to inject the flow service dependency
        public FlowController(IFlowServiceInterface flowService)
        {
            _flowService = flowService;
        }

        /// <summary>
        /// Retrieves all flows.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var flowListResponse = _flowService.GetAll();

            // Check if the response is null or has no data
            if (flowListResponse == null || !flowListResponse.Data.Any())
            {
                return NotFound(new FlowListResponseDTO
                {
                    Message = "No flows found.",
                    Code = "404",
                    Data = new List<FlowViewModelDTO>()
                });
            }

            return Ok(flowListResponse);
        }

        /// <summary>
        /// Retrieves a flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow.</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flowResponse = _flowService.GetById(id);

            // Check if the flow with the given ID exists
            if (flowResponse == null)
            {
                return NotFound(new SingleFlowResponseDTO
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(flowResponse);
        }

        /// <summary>
        /// Creates a new flow.
        /// </summary>
        /// <param name="flowDto">The data of the flow to be created.</param>
        [HttpPost]
        public IActionResult Save([FromBody] CreateFlowRequestDTO flowDto)
        {
            // Validate the input data
            if (flowDto == null)
            {
                return BadRequest("Flow data is required.");
            }

            var createdFlowResponse = _flowService.Save(flowDto);

            // Check if the flow was created successfully
            if (createdFlowResponse == null)
            {
                return BadRequest(new SingleFlowResponseDTO
                {
                    Message = "Flow could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Return the location of the created resource
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFlowResponse.Data?.Id },
                createdFlowResponse
            );
        }

        /// <summary>
        /// Updates an existing flow.
        /// </summary>
        /// <param name="id">The ID of the flow to be updated.</param>
        /// <param name="flowDto">The updated data for the flow.</param>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFlowRequestDTO flowDto)
        {
            // Validate the input data
            if (flowDto == null)
            {
                return BadRequest("Flow data is required.");
            }

            var existingFlowResponse = _flowService.GetById(id);

            // Check if the flow with the given ID exists
            if (existingFlowResponse == null)
            {
                return NotFound(new SingleFlowResponseDTO
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFlowResponse = _flowService.Update(id, flowDto);

            // Check if the update was successful
            if (updatedFlowResponse == null)
            {
                return BadRequest(new SingleFlowResponseDTO
                {
                    Message = "Flow could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to be deleted.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var flowResponse = _flowService.GetById(id);

            // Check if the flow with the given ID exists
            if (flowResponse == null)
            {
                return NotFound(new SingleFlowResponseDTO
                {
                    Message = "Flow not found.",
                    Code = "404",
                    Data = null
                });
            }

            _flowService.Delete(id);
            return NoContent();
        }
    }
}
