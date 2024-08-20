using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Interfaces.Entities.TagEntity
{
    /// <summary>
    /// Interface para definir a estrutura da entidade de etiqueta.
    /// </summary>
    public interface ITagEntityInterface
    {
        /// <summary>
        /// Identificador único da etiqueta.
        /// Deve ser um valor único para cada etiqueta e geralmente é gerado automaticamente.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Nome da etiqueta.
        /// Representa o nome pelo qual a etiqueta é conhecida.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Descrição da etiqueta.
        /// Utilizada para fornecer detalhes adicionais sobre a etiqueta.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Identificador do setor associado à etiqueta.
        /// Chave estrangeira que faz referência ao setor ao qual a etiqueta pertence.
        /// </summary>
        int SectorId { get; set; }

        /// <summary>
        /// Setor associado à etiqueta.
        /// Representa a relação de chave estrangeira com a entidade de setor.
        /// </summary>
        Sector Sector { get; set; }
    }
}
