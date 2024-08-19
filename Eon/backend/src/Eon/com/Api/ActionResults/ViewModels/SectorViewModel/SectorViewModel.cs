namespace Eon.Com.Api.ActionResults.ViewModels.SectorViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados do setor na API.
    /// </summary>
    public class SectorViewModel
    {
        // Identificador único do setor
        public int Id { get; }

        // Nome do setor
        public string Name { get; }

        // Descrição do setor
        public string Description { get; }

        // Identificador do usuário responsável pelo setor
        public int UserBusinessId { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public SectorViewModel()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            UserBusinessId = 0;
        }

        /// <summary>
        /// Construtor para inicializar o modelo com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único do setor.</param>
        /// <param name="name">Nome do setor.</param>
        /// <param name="description">Descrição do setor.</param>
        /// <param name="userBusinessId">Identificador do usuário responsável pelo setor.</param>
        public SectorViewModel(int id, string name, string description, int userBusinessId)
        {
            Id = id;
            Name = name;
            Description = description;
            UserBusinessId = userBusinessId;
        }
    }
}
