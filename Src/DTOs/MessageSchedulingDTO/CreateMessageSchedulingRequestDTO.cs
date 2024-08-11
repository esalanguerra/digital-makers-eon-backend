using System.Text.Json.Serialization;

namespace Eon.DTOs.MessageSchedulingDTO
{
    public class CreateMessageSchedulingRequestDTO
    {
        // Mensagem de texto
        public string MessageText { get; set; }

        // Tag
        public string Tag { get; set; }

        // ID do usuário
        public int UserId { get; set; }

        // Data de envio
        public DateTime SendDate { get; set; }

        // Fluxo
        public string Flow { get; set; }

        // Número do WhatsApp
        public string WhatsAppNumber { get; set; }

        // Status
        public string Status { get; set; } // Agendada, Enviada, Cancelada
        public object ScheduledDate { get; internal set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public CreateMessageSchedulingRequestDTO(string messageText, string tag, int userId, DateTime sendDate, string flow, string whatsAppNumber, string status)
        {
            MessageText = messageText;
            Tag = tag;
            UserId = userId;
            SendDate = sendDate;
            Flow = flow;
            WhatsAppNumber = whatsAppNumber;
            Status = status;
        }
    }
}
