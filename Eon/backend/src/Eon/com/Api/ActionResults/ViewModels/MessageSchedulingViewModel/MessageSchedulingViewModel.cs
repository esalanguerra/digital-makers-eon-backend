namespace Eon.Com.Api.ActionResults.ViewModels.MessageSchedulingViewModel
{
    /// <summary>
    /// Representa o modelo de visualização para dados de mensagens agendadas na API.
    /// </summary>
    public class MessageSchedulingViewModel
    {
        // Identificador único da mensagem agendada
        public int Id { get; }
        
        // Texto da mensagem
        public string MessageText { get; }
        
        // Identificador da etiqueta associada à mensagem
        public int TagId { get; }
        
        // Identificador do usuário responsável pela mensagem
        public int UserId { get; }
        
        // Identificador do fluxo associado à mensagem
        public int FlowId { get; }
        
        // Data e hora de envio da mensagem
        public DateTime SendDate { get; }
        
        // Número de WhatsApp para o qual a mensagem será enviada
        public string WhatsAppNumber { get; }
        
        // Status da mensagem (Agendada, Enviada, Cancelada)
        public string Status { get; }

        /// <summary>
        /// Construtor padrão que inicializa as propriedades com valores padrão.
        /// </summary>
        public MessageSchedulingViewModel()
        {
            Id = 0;
            MessageText = string.Empty;
            TagId = 0;
            UserId = 0;
            FlowId = 0;
            SendDate = DateTime.MinValue;
            WhatsAppNumber = string.Empty;
            Status = string.Empty;
        }

        /// <summary>
        /// Construtor para inicializar o ViewModel com valores específicos.
        /// </summary>
        /// <param name="id">Identificador único da mensagem agendada.</param>
        /// <param name="messageText">Texto da mensagem.</param>
        /// <param name="tagId">Identificador da etiqueta associada à mensagem.</param>
        /// <param name="userId">Identificador do usuário responsável pela mensagem.</param>
        /// <param name="flowId">Identificador do fluxo associado à mensagem.</param>
        /// <param name="sendDate">Data e hora de envio da mensagem.</param>
        /// <param name="whatsAppNumber">Número de WhatsApp para o qual a mensagem será enviada.</param>
        /// <param name="status">Status da mensagem (Agendada, Enviada, Cancelada).</param>
        public MessageSchedulingViewModel(int id, string messageText, int tagId, int userId, int flowId, DateTime sendDate, string whatsAppNumber, string status)
        {
            Id = id;
            MessageText = messageText;
            TagId = tagId;
            UserId = userId;
            FlowId = flowId;
            SendDate = sendDate;
            WhatsAppNumber = whatsAppNumber;
            Status = status;
        }
    }
}
