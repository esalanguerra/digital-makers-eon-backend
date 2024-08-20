using Eon.Com.Api.ActionResults.ViewModels.FlowViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FlowApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de um único fluxo.
    /// </summary>
    public class SingleFlowResponse
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
        /// Dados do fluxo encapsulados em FlowViewModel.
        /// </summary>
        public FlowViewModel Data { get; set; } = new FlowViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="flow">Dados do fluxo.</param>
        public SingleFlowResponse(string message, string code, FlowViewModel flow)
        {
            Message = message;
            Code = code;
            Data = flow;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleFlowResponse()
        {
        }
    }
}
