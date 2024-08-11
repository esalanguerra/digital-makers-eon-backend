namespace Eon.DTOs.FlowDTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a single flow response.
    /// </summary>
    public class SingleFlowResponseDTO
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
        /// Gets or sets the data of the flow encapsulated in <see cref="FlowViewModelDTO"/>.
        /// </summary>
        public FlowViewModelDTO Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleFlowResponseDTO"/> class with specified values.
        /// </summary>
        /// <param name="message">The response message.</param>
        /// <param name="code">The response code.</param>
        /// <param name="flow">The data of the flow.</param>
        public SingleFlowResponseDTO(string message, string code, FlowViewModelDTO flow)
        {
            Message = message;
            Code = code;
            Data = flow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleFlowResponseDTO"/> class with default values.
        /// </summary>
        public SingleFlowResponseDTO()
        {
        }
    }
}
