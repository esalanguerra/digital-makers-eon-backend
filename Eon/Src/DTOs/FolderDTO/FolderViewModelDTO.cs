namespace Eon.DTOs.FolderDTO
{
    public class FolderViewModelDTO
    {
        // Identificador único da pasta
        public int Id { get; set; }

        // Nome da pasta
        public string Name { get; set; }

        // Construtor padrão
        public FolderViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public FolderViewModelDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
