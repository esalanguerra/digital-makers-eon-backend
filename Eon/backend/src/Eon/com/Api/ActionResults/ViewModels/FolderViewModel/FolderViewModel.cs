using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Api.ActionResults.ViewModels.FolderViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados de pastas na API.
    /// </summary>
    public class FolderViewModel
    {
        // Identificador único da pasta
        public int Id { get; }
        
        // Nome da pasta
        public string Name { get; }
        
        // Identificador do setor associado à pasta
        public int SectorId { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public FolderViewModel()
        {
            Id = 0;
            Name = string.Empty;
            SectorId = 0;
        }

        /// <summary>
        /// Construtor para inicializar o ViewModel com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único da pasta.</param>
        /// <param name="name">Nome da pasta.</param>
        /// <param name="sectorId">Identificador do setor associado à pasta.</param>
        /// <param name="sector">Setor associado à pasta.</param>
        public FolderViewModel(int id, string name, int sectorId)
        {
            Id = id;
            Name = name;
            SectorId = sectorId;
        }
    }
}
