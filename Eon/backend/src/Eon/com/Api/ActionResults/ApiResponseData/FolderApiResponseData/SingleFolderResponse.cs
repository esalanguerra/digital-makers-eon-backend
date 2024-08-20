using Eon.Com.Api.ActionResults.ViewModels.FolderViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.FolderApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de uma única pasta.
    /// </summary>
    public class SingleFolderResponse
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
        /// Dados da pasta encapsulados em FolderViewModel.
        /// </summary>
        public FolderViewModel Data { get; set; } = new FolderViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="folder">Dados da pasta.</param>
        public SingleFolderResponse(string message, string code, FolderViewModel folder)
        {
            Message = message;
            Code = code;
            Data = folder;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleFolderResponse()
        {
        }
    }
}
