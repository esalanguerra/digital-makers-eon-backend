using System.Text.Json.Serialization;

namespace Eon.DTOs.TagDTO
{
    public class CreateTagRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateTagRequestDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
