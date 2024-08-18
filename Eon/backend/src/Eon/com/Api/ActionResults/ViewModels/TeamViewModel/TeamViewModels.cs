namespace Eon.Com.Api.ActionResults.ViewModels.TeamViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados do time na API.
    /// </summary>
    public class TeamViewModel
    {
        // Identificador único do time
        public int Id { get; }
        
        // Nome do time
        public string Name { get; }
        
        // Descrição do time
        public string Description { get; }
        
        // Identificador do setor associado ao time
        public int SectorId { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public TeamViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            SectorId = 0;
        }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do time.</param>
        /// <param name="name">Nome do time.</param>
        /// <param name="description">Descrição do time.</param>
        /// <param name="sectorId">Identificador do setor associado ao time.</param>
        /// <param name="sectorName">Nome do setor associado ao time (opcional).</param>
        public TeamViewModel(int id, string name, string description, int sectorId)
        {
            Id = id;
            Name = name;
            Description = description;
            SectorId = sectorId;
        }
    }
}
