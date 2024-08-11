using System.Text.Json.Serialization;

namespace Eon.DTOs.FolderDTO
{
    public class CreateFolderRequestDTO
    {
        // Nome da pasta
        public string Name { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateFolderRequestDTO(string name)
        {
            Name = name;
        }
    }
}
