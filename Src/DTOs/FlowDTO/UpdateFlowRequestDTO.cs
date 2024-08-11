using System.Text.Json.Serialization;

namespace Eon.DTOs.FlowDTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for updating an existing flow.
    /// </summary>
    public class UpdateFlowRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the flow. This field is optional.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the folder of the flow. This field is optional.
        /// </summary>
        public string? Folder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateFlowRequestDTO"/> class with specified values.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        /// <param name="folder">The folder of the flow.</param>
        [JsonConstructor]
        public UpdateFlowRequestDTO(string? name, string? folder)
        {
            Name = name;
            Folder = folder;
        }
    }
}
