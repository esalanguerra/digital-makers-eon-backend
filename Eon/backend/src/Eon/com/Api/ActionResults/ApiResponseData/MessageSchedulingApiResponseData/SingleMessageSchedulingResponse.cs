using Eon.Com.Api.ActionResults.ViewModels.MessageSchedulingViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.MessageSchedulingApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de uma única mensagem agendada.
    /// </summary>
    public class SingleMessageSchedulingResponse
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
        /// Dados da mensagem agendada encapsulados em MessageSchedulingViewModel.
        /// </summary>
        public MessageSchedulingViewModel Data { get; set; } = new MessageSchedulingViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="messageScheduling">Dados da mensagem agendada.</param>
        public SingleMessageSchedulingResponse(string message, string code, MessageSchedulingViewModel messageScheduling)
        {
            Message = message;
            Code = code;
            Data = messageScheduling;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleMessageSchedulingResponse()
        {
        }
    }
}
