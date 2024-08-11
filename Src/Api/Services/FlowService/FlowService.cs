using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.FlowDTO;
using Eon.Data.Interfaces.IFactories;

namespace Eon.Api.Services.FlowService
{
    public class FlowService : IFlowServiceInterface
    {
        private readonly IFlowRepositoryInterface _flowRepository;
        private readonly IFlowFactoryInterface _flowFactory;

        // Construtor para injeção de dependências
        public FlowService(IFlowRepositoryInterface flowRepository, IFlowFactoryInterface flowFactory)
        {
            _flowRepository = flowRepository;
            _flowFactory = flowFactory;
        }

        /// <summary>
        /// Retrieves all flows.
        /// </summary>
        /// <returns>A FlowListResponseDTO containing all flows.</returns>
        public FlowListResponseDTO GetAll()
        {
            var flows = _flowRepository.GetAll();
            return new FlowListResponseDTO
            {
                Message = "Success",
                Code = "200",
                Data = flows // Ajuste conforme o tipo de retorno do repositório
            };
        }

        /// <summary>
        /// Retrieves a flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow.</param>
        /// <returns>A SingleFlowResponseDTO with the flow data or an error message.</returns>
        public SingleFlowResponseDTO? GetById(int id)
        {
            var flow = _flowRepository.GetById(id);

            if (flow == null)
            {
                return new SingleFlowResponseDTO
                {
                    Message = "Flow not found",
                    Code = "404",
                    Data = null
                };
            }

            return new SingleFlowResponseDTO
            {
                Message = "Flow found",
                Code = "200",
                Data = flow
            };
        }

        /// <summary>
        /// Retrieves a flow by its name.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        /// <returns>A SingleFlowResponseDTO with the flow data or an error message.</returns>
        public SingleFlowResponseDTO? GetByName(string name)
        {
            var flow = _flowRepository.GetByName(name);

            if (flow == null)
            {
                return new SingleFlowResponseDTO
                {
                    Message = "Flow not found",
                    Code = "404",
                    Data = null
                };
            }

            return new SingleFlowResponseDTO
            {
                Message = "Flow found",
                Code = "200",
                Data = flow
            };
        }

        /// <summary>
        /// Creates a new flow based on the provided CreateFlowRequestDTO.
        /// </summary>
        /// <param name="flowDto">The data for the new flow.</param>
        /// <returns>A SingleFlowResponseDTO indicating the creation status.</returns>
        public SingleFlowResponseDTO Save(CreateFlowRequestDTO flowDto)
        {
            // Validate the request DTO before creation
            _flowFactory.ValidateCreateFlowRequest(flowDto);

            // Create the flow entity from the DTO
            var flow = _flowFactory.CreateFlow(flowDto);

            // Save the flow entity to the repository and return the response
            return new SingleFlowResponseDTO
            {
                Message = "Flow created",
                Code = "201",
                Data = _flowRepository.Save(flow)
            };
        }

        /// <summary>
        /// Updates an existing flow based on the ID and the provided UpdateFlowRequestDTO.
        /// </summary>
        /// <param name="id">The ID of the flow to update.</param>
        /// <param name="flowDto">The updated data for the flow.</param>
        /// <returns>A SingleFlowResponseDTO indicating the update status.</returns>
        public SingleFlowResponseDTO Update(int id, UpdateFlowRequestDTO flowDto)
        {
            var existingFlow = _flowRepository.GetById(id);

            if (existingFlow == null)
            {
                return new SingleFlowResponseDTO
                {
                    Message = "Flow not found",
                    Code = "404",
                    Data = null
                };
            }

            // Update the flow entity with the provided data
            var updatedFlow = _flowFactory.UpdateFlow(existingFlow, flowDto);

            // Save the updated flow to the repository and return the response
            return new SingleFlowResponseDTO
            {
                Message = "Flow updated",
                Code = "200",
                Data = _flowRepository.Update(id, updatedFlow)
            };
        }

        /// <summary>
        /// Deletes a flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to delete.</param>
        /// <returns>A SingleFlowResponseDTO indicating the deletion status.</returns>
        public SingleFlowResponseDTO Delete(int id)
        {
            var flow = _flowRepository.GetById(id);

            if (flow == null)
            {
                return new SingleFlowResponseDTO
                {
                    Message = "Flow not found",
                    Code = "404",
                    Data = null
                };
            }

            // Delete the flow and return the response
            _flowRepository.Delete(id);

            return new SingleFlowResponseDTO
            {
                Message = "Flow deleted",
                Code = "200",
                Data = null
            };
        }
    }
}
