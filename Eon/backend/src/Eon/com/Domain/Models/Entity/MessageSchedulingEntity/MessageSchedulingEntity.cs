using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Eon.Com.Domain.Models.Entity.TagEntity; // Importa a classe Tag para o relacionamento
using Eon.Com.Domain.Models.Entity.UserEntity; // Importa a classe User para o relacionamento
using Eon.Com.Domain.Models.Entity.FlowEntity; // Importa a classe Flow para o relacionamento

namespace Eon.Com.Domain.Models.Entity.MessageSchedulingEntity
{
    [Table("mensagens_agendadas")] // Mapeia a classe para a tabela "mensagens_agendadas" no banco de dados
    public class MessageScheduling
    {
        [Key] // Define o campo "id" como chave primária da tabela
        [Column("id")]
        public int Id { get; set; }

        [Column("mensagem_agendada_mensagem_de_texto")] // Define o campo "message_text" na tabela
        [Required] // Torna o campo obrigatório
        public string MessageText { get; set; }

        // Chave estrangeira para a tag
        [Column("mensagem_agendada_etiqueta_id")] // Define o campo "tag_id" na tabela
        public int TagId { get; set; } // Chave estrangeira para a tag

        // Propriedade de navegação para a tag associada
        [ForeignKey(nameof(TagId))] // Define a relação de chave estrangeira com a tabela "etiquetas"
        public virtual Tag Tag { get; set; }

        // Chave estrangeira para o usuário
        [Column("mensagem_agendada_usuario_id")] // Define o campo "user_id" na tabela
        public int UserId { get; set; } // Chave estrangeira para o usuário

        // Propriedade de navegação para o usuário associado
        [ForeignKey(nameof(UserId))] // Define a relação de chave estrangeira com a tabela "usuarios"
        public virtual User User { get; set; }

        // Chave estrangeira para o fluxo
        [Column("mensagem_agendada_fluxo_id")] // Define o campo "flow_id" na tabela
        public int FlowId { get; set; } // Chave estrangeira para o fluxo

        // Propriedade de navegação para o fluxo associado
        [ForeignKey(nameof(FlowId))] // Define a relação de chave estrangeira com a tabela "fluxos"
        public virtual Flow Flow { get; set; }

        [Column("mensagem_agendada_data_envio")] // Define o campo "send_date" na tabela
        [Required] // Torna o campo obrigatório
        public DateTime SendDate { get; set; }

        [Column("mensagem_agendada_numero_whatsapp")] // Define o campo "whatsapp_number" na tabela
        [Required] // Torna o campo obrigatório
        public string WhatsAppNumber { get; set; }

        [Column("mensagem_agendada_status")] // Define o campo "status" na tabela
        [Required] // Torna o campo obrigatório
        public string Status { get; set; } // Status da mensagem: Agendada, Enviada, Cancelada

        // Construtor padrão
        public MessageScheduling()
        {
            MessageText = string.Empty; // Inicializa MessageText como uma string vazia
            TagId = 0; // Inicializa TagId como 0
            UserId = 0; // Inicializa UserId como 0
            FlowId = 0; // Inicializa FlowId como 0
            SendDate = DateTime.MinValue; // Inicializa SendDate como a menor data possível
            WhatsAppNumber = string.Empty; // Inicializa WhatsAppNumber como uma string vazia
            Status = string.Empty; // Inicializa Status como uma string vazia
            Tag = new Tag(); // Inicializa a propriedade de navegação Tag
            User = new User(); // Inicializa a propriedade de navegação User
            Flow = new Flow(); // Inicializa a propriedade de navegação Flow
        }

        // Construtor que inicializa a classe com valores específicos
        public MessageScheduling(string messageText, int tagId, int userId, int flowId, DateTime sendDate, string whatsAppNumber, string status, Tag tag, User user, Flow flow)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText)); // Garante que a mensagem não seja nula
            TagId = tagId; // Inicializa TagId
            UserId = userId; // Inicializa UserId
            FlowId = flowId; // Inicializa FlowId
            SendDate = sendDate; // Inicializa SendDate
            WhatsAppNumber = whatsAppNumber ?? throw new ArgumentNullException(nameof(whatsAppNumber)); // Garante que o número de WhatsApp não seja nulo
            Status = status ?? throw new ArgumentNullException(nameof(status)); // Garante que o status não seja nulo
            Tag = tag ?? throw new ArgumentNullException(nameof(tag)); // Garante que a tag não seja nula
            User = user ?? throw new ArgumentNullException(nameof(user)); // Garante que o usuário não seja nulo
            Flow = flow ?? throw new ArgumentNullException(nameof(flow)); // Garante que o fluxo não seja nulo
        }
    }
}
