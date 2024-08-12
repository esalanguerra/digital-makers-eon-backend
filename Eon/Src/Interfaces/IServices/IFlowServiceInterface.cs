using Eon.DTOs.FlowDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface IFlowServiceInterface
    {
        /// <summary>
        /// Retrieves all flows.
        /// </summary>
        /// <returns>A FlowListResponseDTO containing a collection of flows with a message and status code.</returns>
        FlowListResponseDTO GetAll();

        /// <summary>
        /// Retrieves a specific flow by its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to retrieve.</param>
        /// <returns>A SingleFlowResponseDTO with the flow data, or null if the flow is not found.</returns>
        SingleFlowResponseDTO? GetById(int id);

        /// <summary>
        /// Retrieves a specific flow by its name.
        /// </summary>
        /// <param name="name">The name of the flow to retrieve.</param>
        /// <returns>A SingleFlowResponseDTO with the flow data, or null if the flow is not found.</returns>
        SingleFlowResponseDTO? GetByName(string name);

        /// <summary>
        /// Creates a new flow based on the provided CreateFlowRequestDTO.
        /// </summary>
        /// <param name="flowDto">The data for the new flow.</param>
        /// <returns>A SingleFlowResponseDTO indicating the result of the creation operation.</returns>
        SingleFlowResponseDTO? Save(CreateFlowRequestDTO flowDto);

        /// <summary>
        /// Updates an existing flow with the specified ID using the provided UpdateFlowRequestDTO.
        /// </summary>
        /// <param name="id">The ID of the flow to update.</param>
        /// <param name="flowDto">The updated data for the flow.</param>
        /// <returns>A SingleFlowResponseDTO indicating the result of the update operation.</returns>
        SingleFlowResponseDTO? Update(int id, UpdateFlowRequestDTO flowDto);

        /// <summary>
        /// Deletes a flow based on its ID.
        /// </summary>
        /// <param name="id">The ID of the flow to delete.</param>
        /// <returns>A SingleFlowResponseDTO indicating the result of the deletion operation, or null if the flow is not found.</returns>
        SingleFlowResponseDTO? Delete(int id);
    }
}
