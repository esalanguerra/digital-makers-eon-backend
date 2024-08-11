using System.Text.Json.Serialization;

namespace Eon.DTOs.FolderDTO
{
    public class UpdateFolderRequestDTO
    {
        // Nome da pasta (opcional)
        public string? Name { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateFolderRequestDTO(string? name)
        {
            Name = name;
        }
    }
}
