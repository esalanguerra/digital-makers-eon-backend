namespace Eon.Com.Api.ActionResults.ViewModels.FlowViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados do fluxo na API.
    /// </summary>
    public class FlowViewModel
    {
        // Identificador único do fluxo
        public int Id { get; }
        
        // Nome do fluxo
        public string Name { get; }
        
        // Identificador da pasta associada ao fluxo
        public int FolderId { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public FlowViewModel()
        {
            Id = 0;
            Name = string.Empty;
            FolderId = 0;
        }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do fluxo.</param>
        /// <param name="name">Nome do fluxo.</param>
        /// <param name="folderId">Identificador da pasta associada ao fluxo.</param>
        /// <param name="folderName">Nome da pasta associada ao fluxo (opcional).</param>
        public FlowViewModel(int id, string name, int folderId)
        {
            Id = id;
            Name = name;
            FolderId = folderId;
        }
    }
}
