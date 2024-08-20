using Eon.Com.Api.ActionResults.ViewModels.FlowSharedViewModel;
using System.Collections.Generic;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FlowSharedApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de fluxos compartilhados.
    /// </summary>
    public class FlowSharedListResponse
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
        /// Lista de fluxos compartilhados encapsulados em FlowSharedViewModel.
        /// </summary>
        public IEnumerable<FlowSharedViewModel> Data { get; set; } = new List<FlowSharedViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="flowShareds">Lista de fluxos compartilhados.</param>
        public FlowSharedListResponse(string message, string code, IEnumerable<FlowSharedViewModel> flowShareds)
        {
            Message = message;
            Code = code;
            Data = flowShareds ?? new List<FlowSharedViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public FlowSharedListResponse()
        {
            Data = new List<FlowSharedViewModel>();
        }
    }
}
