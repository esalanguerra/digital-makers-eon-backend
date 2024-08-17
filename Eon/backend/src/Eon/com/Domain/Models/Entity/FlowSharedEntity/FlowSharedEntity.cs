using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Com.Domain.Models.Entity.FlowSharedEntity
{
    // Mapeia a classe SharedFlow para a tabela "fluxos_compartilhados" no banco de dados
    [Table("fluxos_compartilhados")]
    public class FlowShared
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "id_fluxo" como obrigatório
        [Column("id_fluxo")]
        [Required]
        public int FlowId { get; set; }

         // Define o campo "id_usuario" como obrigatório
        [Column("id_usuario")]
        [Required]
        public int UserId { get; set; }

        [Column("link")]
        [Required]
        public string Link { get; set; }

        [Column("status")]
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
            Link = link ?? throw new ArgumentNullException(nameof(link));
            Status = status;
        }
    }
}
