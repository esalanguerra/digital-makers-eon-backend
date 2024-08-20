using Eon.Com.Domain.Models.Entity.SectorEntity;

namespace Eon.Com.Interfaces.Entities.FolderEntity
{
    // Interface para definir a estrutura da entidade de pasta.
    public interface IFolderEntityInterface
    {
        // Identificador único da pasta.
        // Deve ser um valor único para cada pasta e geralmente é gerado automaticamente.
        int Id { get; set; }

        // Nome da pasta.
        // Representa o nome da pasta na qual os dados ou arquivos são armazenados.
        string Name { get; set; }

        // Identificador do setor associado.
        // Utilizado para referenciar o setor ao qual a pasta pertence.
        int SectorId { get; set; }

        // Setor associado à pasta.
        // Propriedade de navegação para o setor relacionado.
        Sector Sector { get; set; }
    }
}
