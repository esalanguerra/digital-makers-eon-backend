using Eon.Com.Api.ActionResults.ViewModels.TagViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.TagApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de etiquetas.
    /// </summary>
    public class TagListResponse
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
        /// Lista de etiquetas encapsuladas em TagViewModel.
        /// </summary>
        public IEnumerable<TagViewModel> Data { get; set; } = new List<TagViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="tags">Lista de etiquetas.</param>
        public TagListResponse(string message, string code, IEnumerable<TagViewModel> tags)
        {
            Message = message;
            Code = code;
            Data = tags ?? new List<TagViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public TagListResponse()
        {
            Data = new List<TagViewModel>();
        }
    }
}
