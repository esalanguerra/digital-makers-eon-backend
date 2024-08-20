using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Interfaces.Entities.TeamEntity
{
    /// <summary>
    /// Interface para definir a estrutura da entidade de equipe.
    /// </summary>
    public interface ITeamEntityInterface
    {
        /// <summary>
        /// Identificador único da equipe.
        /// Deve ser um valor único para cada equipe e geralmente é gerado automaticamente.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Nome da equipe.
        /// Representa o nome pelo qual a equipe é conhecida.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Descrição da equipe.
        /// Utilizada para fornecer detalhes adicionais sobre a equipe.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Identificador do setor associado à equipe.
        /// Chave estrangeira que faz referência ao setor ao qual a equipe pertence.
        /// </summary>
        int SectorId { get; set; }

        /// <summary>
        /// Setor associado à equipe.
        /// Representa a relação de chave estrangeira com a entidade de setor.
        /// </summary>
        Sector Sector { get; set; }
    }
}
