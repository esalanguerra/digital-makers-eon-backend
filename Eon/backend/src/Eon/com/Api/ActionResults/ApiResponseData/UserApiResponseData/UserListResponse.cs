using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData
{
    public class UserListResponseDTO
    {
        // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
        public string Message { get; set; } = string.Empty;

        // Código de resposta (por exemplo, um código de status ou erro)
        public string Code { get; set; } = string.Empty;

        // Lista de usuários encapsulados em UserViewModel
        public IEnumerable<UserViewModel> Data { get; set; } = new List<UserViewModel>();

        // Construtor para inicializar o DTO com valores específicos
        public UserListResponseDTO(string message, string code, IEnumerable<UserViewModel> users)
        {
            Message = message;
            Code = code;
            Data = users;
        }

        // Construtor padrão
        public UserListResponseDTO()
        {
            Data = new List<UserViewModel>();
        }
    }
}
