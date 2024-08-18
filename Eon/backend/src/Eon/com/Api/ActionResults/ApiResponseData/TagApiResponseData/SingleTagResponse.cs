using Eon.Com.Api.ActionResults.ViewModels.TagViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.TagApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de uma única etiqueta.
    /// </summary>
    public class SingleTagResponse
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
        /// Dados da etiqueta encapsulados em TagViewModel.
        /// </summary>
        public TagViewModel Data { get; set; } = new TagViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="tag">Dados da etiqueta.</param>
        public SingleTagResponse(string message, string code, TagViewModel tag)
        {
            Message = message;
            Code = code;
            Data = tag;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleTagResponse()
        {
        }
    }
}
