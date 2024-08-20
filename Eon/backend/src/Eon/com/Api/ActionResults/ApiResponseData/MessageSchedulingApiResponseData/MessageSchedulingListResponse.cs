using Eon.Com.Api.ActionResults.ViewModels.MessageSchedulingViewModel;
using System.Collections.Generic;

namespace Eon.Com.Api.ActionResults.ApiResponseData.MessageSchedulingApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de mensagens agendadas.
    /// </summary>
    public class MessageSchedulingListResponse
    {
        /// <summary>
        /// Mensagem de resposta (por exemplo, "Sucesso" ou "Erro").
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Código de resposta (por exemplo, um código de status ou erro).
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Lista de mensagens agendadas encapsuladas em MessageSchedulingViewModel.
        /// </summary>
        public IEnumerable<MessageSchedulingViewModel> Data { get; set; } = new List<MessageSchedulingViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="messageSchedulingList">Lista de mensagens agendadas.</param>
        public MessageSchedulingListResponse(string message, string code, IEnumerable<MessageSchedulingViewModel> messageSchedulingList)
        {
            Message = message;
            Code = code;
            Data = messageSchedulingList ?? new List<MessageSchedulingViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public MessageSchedulingListResponse()
        {
            Data = new List<MessageSchedulingViewModel>();
        }
    }
}
