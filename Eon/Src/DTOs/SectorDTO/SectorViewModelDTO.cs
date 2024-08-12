namespace Eon.DTOs.SectorDTO
{
    public class SectorViewModelDTO
    {
        // Identificador único do setor
        public int Id { get; set; }

        // Equipe
        public string[] Team { get; set; }

        // Descrição do setor
        public string Description { get; set; }

        // ID do time
        public int TeamId { get; set; }

        // Construtor padrão
        public SectorViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public SectorViewModelDTO(int id, string[] team, string description, int teamId)
        {
            Id = id;
            Team = team;
            Description = description;
            TeamId = teamId;
        }
    }
}
