using Eon.Com.Domain.Models.Entity.FolderEntity;

namespace Eon.Com.Interfaces.Entities.FlowEntity
{
    // Interface para definir a estrutura da entidade Flow.
    public interface IFlowEntityInterface
    {
        // Identificador único do fluxo.
        // Deve ser um valor único para cada fluxo e geralmente é gerado automaticamente.
        int Id { get; set; }

        // Nome do fluxo.
        // Representa o nome do fluxo associado à entidade.
        string Name { get; set; }

        // Identificador da pasta.
        // Representa o ID da pasta associada ao fluxo.
        int FolderId { get; set; }

        // Propriedade de navegação para a pasta.
        // Representa a pasta associada ao fluxo.
        Folder Folder { get; set; }
    }
}
