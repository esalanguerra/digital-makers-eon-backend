namespace Eon.DTOs.TagDTO
{
    public class TagViewModelDTO
    {
        // Identificador único da etiqueta
        public int Id { get; set; }

        // Nome da etiqueta
        public string Name { get; set; }

        // Descrição da etiqueta
        public string? Description { get; set; }

        // Construtor padrão
        public TagViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public TagViewModelDTO(int id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
