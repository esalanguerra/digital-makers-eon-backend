using System;
using System.Text.Json.Serialization;

namespace Eon.Com.Domain.Models.Dto.MessageSchedulingDto
{
    /// <summary>
    /// DTO para a atualização das informações de uma mensagem agendada.
    /// </summary>
    public class UpdateMessageSchedulingRequestDTO
    {
        /// <summary>
        /// Texto da mensagem. Este campo é opcional.
        /// </summary>
        public string? MessageText { get; set; }

        /// <summary>
        /// Identificador da etiqueta associada à mensagem. Este campo é opcional.
        /// </summary>
        public int? TagId { get; set; }

        /// <summary>
        /// Identificador do usuário responsável pela mensagem. Este campo é opcional.
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Identificador do fluxo ao qual a mensagem está associada. Este campo é opcional.
        /// </summary>
        public int? FlowId { get; set; }

        /// <summary>
        /// Data de envio da mensagem. Este campo é opcional.
        /// </summary>
        public DateTime? SendDate { get; set; }

        /// <summary>
        /// Número de WhatsApp para o qual a mensagem será enviada. Este campo é opcional.
        /// </summary>
        public string? WhatsAppNumber { get; set; }

        /// <summary>
        /// Status da mensagem (e.g., Agendada, Enviada, Cancelada). Este campo é opcional.
        /// </summary>
        public string? Status { get; set; }

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
        public UpdateMessageSchedulingRequestDTO(
            string? messageText = null, 
            int? tagId = null, 
            int? userId = null, 
            int? flowId = null, 
            DateTime? sendDate = null, 
            string? whatsAppNumber = null, 
            string? status = null)
        {
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
