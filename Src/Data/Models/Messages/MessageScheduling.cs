using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eon.Data.Models.Messages
{
    // Mapeia a classe User para a tabela "usuarios" no banco de dados
    [Table("mensagens_agendadas")]
    public class MessageScheduling
    {
        // Define o campo "id" como chave primária da tabela
        [Key]
        [Column("id")]
        public int Id { get; set; }

        // Define o campo "mensagem" como obrigatório
        [Column("mensagem_de_texto")]
        [Required]
        public string MessageText { get; set; }

        // Define o campo "tag" como obrigatório
        [Column("id_etiqueta")]
        [Required]
        public string Tag { get; set; }

        // Define o campo "id_usuario" como obrigatório
        [Column("id_usuario")]
        [Required]
        public int UserId { get; set; }

        // Define o campo "data_envio" como obrigatório
        [Column("data_envio")]
        [Required]
        public DateTime SendDate { get; set; }

        [Column("id_fluxo")]
        [Required]
        public string Flow { get; set; }

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
            Tag = string.Empty;
            UserId = 0;
            SendDate = DateTime.MinValue;
            Flow = string.Empty;
            WhatsAppNumber = string.Empty;
            Status = string.Empty;
        }

        // Construtor que inicializa a classe com valores específicos
        public MessageScheduling(string messageText, string tag, int userId, DateTime sendDate, string flow, string whatsAppNumber, string status)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText)); // Garante que a mensagem não seja nula
            Tag = tag ?? throw new ArgumentNullException(nameof(tag)); // Garante que a tag não seja nula
            UserId = userId;
            SendDate = sendDate;
            Flow = flow ?? throw new ArgumentNullException(nameof(flow)); // Garante que o fluxo não seja nulo
            WhatsAppNumber = whatsAppNumber ?? throw new ArgumentNullException(nameof(whatsAppNumber)); // Garante que o número de WhatsApp não seja nulo
            Status = status ?? throw new ArgumentNullException(nameof(status)); // Garante que o status não seja nulo
        }
    }
}
