using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.TagEntity; // Importa a classe Tag para o relacionamento
using Eon.Com.Domain.Models.Entity.UserEntity; // Importa a classe User para o relacionamento
using Eon.Com.Domain.Models.Entity.FlowEntity; // Importa a classe Flow para o relacionamento

namespace Eon.Com.Domain.Models.Entity.MessageSchedulingEntity
{
    [Table("mensagens_agendadas")]
    public class MessageScheduling
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("mensagem_de_texto")]
        [Required]
        public string MessageText { get; set; }

        // Chave estrangeira para a tag
        [Column("etiqueta_id")]
        public int TagId { get; set; } // Chave estrangeira para a tag

        // Propriedade de navegação para a tag associada
        [ForeignKey(nameof(TagId))]
        public virtual Tag Tag { get; set; }

        // Chave estrangeira para o usuário
        [Column("id_usuario")]
        public int UserId { get; set; } // Chave estrangeira para o usuário

        // Propriedade de navegação para o usuário associado
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        // Chave estrangeira para o fluxo
        [Column("id_fluxo")]
        public int FlowId { get; set; } // Chave estrangeira para o fluxo

        // Propriedade de navegação para o fluxo associado
        [ForeignKey(nameof(FlowId))]
        public virtual Flow Flow { get; set; }

        [Column("data_envio")]
        [Required]
        public DateTime SendDate { get; set; }

        [Column("numero_whatsapp")]
        [Required]
        public string WhatsAppNumber { get; set; }

        [Column("status")]
        [Required]
        public string Status { get; set; } // Agendada, Enviada, Cancelada

        // Construtor padrão
        public MessageScheduling()
        {
            MessageText = string.Empty;
            TagId = 0;
            UserId = 0;
            FlowId = 0;
            SendDate = DateTime.MinValue;
            WhatsAppNumber = string.Empty;
            Status = string.Empty;
            Tag = new Tag();
            User = new User();
            Flow = new Flow();
        }

        // Construtor que inicializa a classe com valores específicos
        public MessageScheduling(string messageText, int tagId, int userId, int flowId, DateTime sendDate, string whatsAppNumber, string status, Tag tag, User user, Flow flow)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText)); // Garante que a mensagem não seja nula
            TagId = tagId;
            UserId = userId;
            FlowId = flowId;
            SendDate = sendDate;
            WhatsAppNumber = whatsAppNumber ?? throw new ArgumentNullException(nameof(whatsAppNumber)); // Garante que o número de WhatsApp não seja nulo
            Status = status ?? throw new ArgumentNullException(nameof(status)); // Garante que o status não seja nulo
            Tag = tag ?? throw new ArgumentNullException(nameof(tag)); // Garante que a tag não seja nula
            User = user ?? throw new ArgumentNullException(nameof(user)); // Garante que o usuário não seja nulo
            Flow = flow ?? throw new ArgumentNullException(nameof(flow)); // Garante que o fluxo não seja nulo
        }
    }
}
