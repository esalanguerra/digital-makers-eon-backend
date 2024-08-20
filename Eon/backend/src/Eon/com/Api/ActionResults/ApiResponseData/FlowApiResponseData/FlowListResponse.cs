using Eon.Com.Api.ActionResults.ViewModels.FlowViewModel;
using System.Collections.Generic;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FlowApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de fluxos.
    /// </summary>
    public class FlowListResponse
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
        /// Lista de fluxos encapsulados em FlowViewModel.
        /// </summary>
        public IEnumerable<FlowViewModel> Data { get; set; } = new List<FlowViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="flows">Lista de fluxos.</param>
        public FlowListResponse(string message, string code, IEnumerable<FlowViewModel> flows)
        {
            Message = message;
            Code = code;
            Data = flows ?? new List<FlowViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public FlowListResponse()
        {
            Data = new List<FlowViewModel>();
        }
    }
}
