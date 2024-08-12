using System.Collections.Generic;

namespace Eon.DTOs.FlowDTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for a collection of flows.
    /// </summary>
    public class FlowListResponseDTO
    {
        /// <summary>
        /// Gets or sets the response message (e.g., "Success" or "Error").
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the response code (e.g., a status or error code).
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the list of flows encapsulated in <see cref="FlowViewModelDTO"/>.
        /// </summary>
        public IEnumerable<FlowViewModelDTO> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowListResponseDTO"/> class with specified values.
        /// </summary>
        /// <param name="message">The response message.</param>
        /// <param name="code">The response code.</param>
        /// <param name="flows">The collection of flows.</param>
        public FlowListResponseDTO(string message, string code, IEnumerable<FlowViewModelDTO> flows)
        {
            Message = message;
            Code = code;
            Data = flows;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowListResponseDTO"/> class with default values.
        /// </summary>
        public FlowListResponseDTO()
        {
            // Initializes Data as an empty list to avoid null reference issues
            Data = new List<FlowViewModelDTO>();
        }
    }
}
