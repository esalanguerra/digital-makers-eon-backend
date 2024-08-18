using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;
using System.Collections.Generic;

namespace Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de usuários.
    /// </summary>
    public class UserListResponse
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
        /// Lista de usuários encapsulados em UserViewModel.
        /// </summary>
        public IEnumerable<UserViewModel> Data { get; set; } = new List<UserViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="users">Lista de usuários.</param>
        public UserListResponse(string message, string code, IEnumerable<UserViewModel> users)
        {
            Message = message;
            Code = code;
            Data = users ?? new List<UserViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public UserListResponse()
        {
            Data = new List<UserViewModel>();
        }
    }
}
