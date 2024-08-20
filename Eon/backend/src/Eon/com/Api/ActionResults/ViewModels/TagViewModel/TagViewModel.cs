namespace Eon.Com.Api.ActionResults.ViewModels.TagViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados da etiqueta na API.
    /// </summary>
    public class TagViewModel
    {
        // Identificador único da etiqueta
        public int Id { get; }
        
        // Nome da etiqueta
        public string Name { get; }
        
        // Descrição da etiqueta
        public string Description { get; }
        
        // Identificador do setor associado à etiqueta
        public int SectorId { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public TagViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            SectorId = 0;
        }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único da etiqueta.</param>
        /// <param name="name">Nome da etiqueta.</param>
        /// <param name="description">Descrição da etiqueta.</param>
        /// <param name="sectorId">Identificador do setor associado à etiqueta.</param>
        public TagViewModel(int id, string name, string description, int sectorId)
        {
            Id = id;
            Name = name;
            Description = description;
            SectorId = sectorId;
        }
    }
}
