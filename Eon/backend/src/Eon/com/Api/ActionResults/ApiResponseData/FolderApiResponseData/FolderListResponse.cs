using Eon.Com.Api.ActionResults.ViewModels.FolderViewModel;
using System.Collections.Generic;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FolderApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de pastas.
    /// </summary>
    public class FolderListResponse
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
        /// Lista de pastas encapsuladas em FolderViewModel.
        /// </summary>
        public IEnumerable<FolderViewModel> Data { get; set; } = new List<FolderViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="folders">Lista de pastas.</param>
        public FolderListResponse(string message, string code, IEnumerable<FolderViewModel> folders)
        {
            Message = message;
            Code = code;
            Data = folders ?? new List<FolderViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public FolderListResponse()
        {
            Data = new List<FolderViewModel>();
        }
    }
}
