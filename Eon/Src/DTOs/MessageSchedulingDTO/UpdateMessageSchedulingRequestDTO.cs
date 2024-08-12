using System.Text.Json.Serialization;

namespace Eon.DTOs.MessageSchedulingDTO
{
    public class UpdateMessageSchedulingRequestDTO
    {
        // Mensagem de texto (opcional)
        public string? MessageText { get; set; }

        // Tag (opcional)
        public string? Tag { get; set; }

        // Data de envio (opcional)
        public DateTime? SendDate { get; set; }

        // Fluxo (opcional)
        public string? Flow { get; set; }

        // Número do WhatsApp (opcional)
        public string? WhatsAppNumber { get; set; }

        // Status (opcional)
        public string? Status { get; set; } // Agendada, Enviada, Cancelada
        public int UserId { get; internal set; }

        // Construtor para inicializar o DTO com valores específicos
        [JsonConstructor]
        public UpdateMessageSchedulingRequestDTO(string? messageText, string? tag, DateTime? sendDate, string? flow, string? whatsAppNumber, string? status)
        {
            MessageText = messageText;
            Tag = tag;
            SendDate = sendDate;
            Flow = flow;
            WhatsAppNumber = whatsAppNumber;
            Status = status;
        }
    }
}
