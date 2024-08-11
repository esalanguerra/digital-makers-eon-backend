namespace Eon.DTOs.FlowDTO
{
    /// <summary>
    /// Data Transfer Object (DTO) for representing a flow with its details.
    /// </summary>
    public class FlowViewModelDTO
    {
        /// <summary>
        /// Gets or sets the unique identifier of the flow.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the flow.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the folder of the flow.
        /// </summary>
        public string Folder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowViewModelDTO"/> class with default values.
        /// </summary>
        public FlowViewModelDTO() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlowViewModelDTO"/> class with specified values.
        /// </summary>
        /// <param name="id">The unique identifier of the flow.</param>
        /// <param name="name">The name of the flow.</param>
        /// <param name="folder">The folder of the flow.</param>
        public FlowViewModelDTO(int id, string name, string folder)
        {
            Id = id;
            Name = name;
            Folder = folder;
        }
    }
}
