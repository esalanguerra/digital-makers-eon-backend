using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de um único usuário.
    /// </summary>
    public class SingleUserResponse
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
        /// Dados do usuário encapsulados em UserViewModel.
        /// </summary>
        public UserViewModel Data { get; set; } = new UserViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="user">Dados do usuário.</param>
        public SingleUserResponse(string message, string code, UserViewModel user)
        {
            Message = message;
            Code = code;
            Data = user;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleUserResponse()
        {
        }
    }
}
