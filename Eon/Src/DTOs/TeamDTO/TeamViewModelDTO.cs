namespace Eon.DTOs.TeamDTO
{
    public class TeamViewModelDTO
    {
        // Identificador único do time
        public int Id { get; set; }

        // Nome do time
        public string Name { get; set; }

        // Descrição do time
        public string Description { get; set; }

        // Construtor padrão
        public TeamViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public TeamViewModelDTO(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
