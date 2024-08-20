using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Interfaces.Entities.FlowSharedEntity;

namespace Eon.Com.Domain.Models.Entity.FlowSharedEntity
{
    // Mapeia a classe SharedFlow para a tabela "fluxos_compartilhados" no banco de dados
    [Table("fluxos_compartilhados")]
    public class FlowShared: IFlowSharedEntityInterface // Implementa a interface IFlowSharedEntityInterface
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "id_fluxo" como obrigatório
        [Column("fluxo_compartilhado_fluxo_id")]
        [Required]
        public int FlowId { get; set; }

        // Define o campo "id_usuario" como obrigatório
        [Column("fluxo_compartilhado_usuario_id")]
        [Required]
        public int UserId { get; set; }

        // Define o campo "link" como obrigatório
        [Column("fluxo_compartilhado_link")]
        [Required]
        public string Link { get; set; }

        // Define o campo "status" como opcional (booleano)
        [Column("fluxo_compartilhado_status")]
        public bool Status { get; set; }

        // Construtor padrão
        public FlowShared()
        {
            FlowId = 0;
            UserId = 0;
            Link = string.Empty;
            Status = false;
        }

        // Construtor que inicializa a classe com valores específicos
        public FlowShared(int flowId, int userId, string link, bool status)
        {
            FlowId = flowId;
            UserId = userId;
            Link = link ?? throw new ArgumentNullException(nameof(link)); // Garante que o link não seja nulo
            Status = status;
        }
    }
}
