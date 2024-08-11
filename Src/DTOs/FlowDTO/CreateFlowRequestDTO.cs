using System.Text.Json.Serialization;

namespace Eon.DTOs.FlowDTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for creating a new flow.
    /// </summary>
    public class CreateFlowRequestDTO
    {
        /// <summary>
        /// Gets or sets the name of the flow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the folder of the flow.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateFlowRequestDTO"/> class with the specified name and folder.
        /// </summary>
        /// <param name="name">The name of the flow.</param>
        /// <param name="folder">The folder of the flow.</param>
        [JsonConstructor]
        public CreateFlowRequestDTO(string name, string folder)
        {
            Name = name;
            Folder = folder;
        }
    }
}
