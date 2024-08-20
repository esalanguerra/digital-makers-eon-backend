using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.MessageSchedulingDto
{
    /// <summary>
    /// DTO para a criação de uma nova mensagem agendada.
    /// </summary>
    public class CreateMessageSchedulingRequestDTO
    {
        /// <summary>
        /// Texto da mensagem. Este campo é obrigatório.
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Identificador da etiqueta associada à mensagem. Este campo é obrigatório.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pela mensagem. Este campo é obrigatório.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Identificador do fluxo ao qual a mensagem está associada. Este campo é obrigatório.
        /// </summary>
        public int FlowId { get; set; }

        /// <summary>
        /// Data de envio da mensagem. Este campo é obrigatório.
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Número de WhatsApp para o qual a mensagem será enviada. Este campo é obrigatório.
        /// </summary>
        public string WhatsAppNumber { get; set; }

        /// <summary>
        /// Status da mensagem (e.g., Agendada, Enviada, Cancelada). Este campo é obrigatório.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="messageText">Texto da mensagem.</param>
        /// <param name="tagId">Identificador da etiqueta.</param>
        /// <param name="userId">Identificador do usuário responsável.</param>
        /// <param name="flowId">Identificador do fluxo.</param>
        /// <param name="sendDate">Data de envio da mensagem.</param>
        /// <param name="whatsAppNumber">Número de WhatsApp.</param>
        /// <param name="status">Status da mensagem.</param>
        [JsonConstructor]
        public CreateMessageSchedulingRequestDTO(
            string messageText, 
            int tagId, 
            int userId, 
            int flowId, 
            DateTime sendDate, 
            string whatsAppNumber, 
            string status)
        {
            MessageText = messageText ?? throw new ArgumentNullException(nameof(messageText)); // Garante que o texto da mensagem não seja nulo
            TagId = tagId; // Inicializa o ID da tag
            UserId = userId; // Inicializa o ID do usuário responsável
            FlowId = flowId; // Inicializa o ID do fluxo
            SendDate = sendDate; // Inicializa a data de envio
            WhatsAppNumber = whatsAppNumber ?? throw new ArgumentNullException(nameof(whatsAppNumber)); // Garante que o número de WhatsApp não seja nulo
            Status = status ?? throw new ArgumentNullException(nameof(status)); // Garante que o status não seja nulo
        }
    }
}
