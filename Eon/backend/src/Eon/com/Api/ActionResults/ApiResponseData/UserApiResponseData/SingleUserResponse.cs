using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData
{
    // DTO para um único usuário
    public class SingleUserResponse
    {
        // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
        public string Message { get; set; } = string.Empty;

        // Código de resposta (por exemplo, um código de status ou erro)
        public string Code { get; set; } = string.Empty;

        // Dados do usuário encapsulados em UserViewModel
        public UserViewModel Data { get; set; } = new UserViewModel();

        // Construtor para inicializar o DTO com valores específicos
        public SingleUserResponse(string message, string code, UserViewModel user)
        {
            Message = message;
            Code = code;
            Data = user;
        }

        // Construtor padrão
        public SingleUserResponse()
        {
        }
    }
}
