namespace Eon.DTOs.MessageSchedulingDTO
{
    public class MessageSchedulingViewModelDTO
    {
        // Identificador único da mensagem agendada
        public int Id { get; set; }

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

        // Construtor padrão
        public MessageSchedulingViewModelDTO() { }

        // Construtor para inicializar o DTO com valores específicos
        public MessageSchedulingViewModelDTO(int id, string messageText, string tag, int userId, DateTime sendDate, string flow, string whatsAppNumber, string status)
        {
            Id = id;
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
