using Eon.Com.Domain.Models.Entity.UserEntity;

namespace Eon.Com.Interfaces.Entities.SectorEntity
{
    /// <summary>
    /// Interface para definir a estrutura da entidade de setor.
    /// </summary>
    public interface ISectorEntityInterface
    {
        /// <summary>
        /// Identificador único do setor.
        /// Deve ser um valor único para cada setor e geralmente é gerado automaticamente.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Nome do setor.
        /// Representa o nome pelo qual o setor é conhecido.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Descrição do setor.
        /// Utilizada para fornecer detalhes adicionais sobre o setor.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pelo setor.
        /// Chave estrangeira que faz referência ao usuário associado ao setor.
        /// </summary>
        int UserBusinessId { get; set; }

        /// <summary>
        /// Usuário responsável pelo setor.
        /// Representa a relação de chave estrangeira com a entidade de usuário.
        /// </summary>
        User UserBusiness { get; set; }
    }
}
