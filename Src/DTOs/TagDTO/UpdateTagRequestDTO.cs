using System.Text.Json.Serialization;

namespace Eon.DTOs.TagDTO
{
    public class UpdateTagRequestDTO
    {
        // Nome da etiqueta
        public string Name { get; set; }

        // Descrição da etiqueta
        public string Description { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateTagRequestDTO(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
