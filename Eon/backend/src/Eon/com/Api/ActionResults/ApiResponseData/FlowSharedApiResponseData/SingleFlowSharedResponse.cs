using Eon.Com.Api.ActionResults.ViewModels.FlowSharedViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FlowSharedApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de um único fluxo compartilhado.
    /// </summary>
    public class SingleFlowSharedResponse
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
        /// Dados do fluxo compartilhado encapsulados em FlowSharedViewModel.
        /// </summary>
        public FlowSharedViewModel Data { get; set; } = new FlowSharedViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="flowShared">Dados do fluxo compartilhado.</param>
        public SingleFlowSharedResponse(string message, string code, FlowSharedViewModel flowShared)
        {
            Message = message;
            Code = code;
            Data = flowShared;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleFlowSharedResponse()
        {
        }
    }
}
