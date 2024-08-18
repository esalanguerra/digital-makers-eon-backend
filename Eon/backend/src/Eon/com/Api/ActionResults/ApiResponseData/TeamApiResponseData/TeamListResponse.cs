using Eon.Com.Api.ActionResults.ViewModels.TeamViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.TeamApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de times.
    /// </summary>
    public class TeamListResponse
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
        /// Lista de times encapsulados em TeamViewModel.
        /// </summary>
        public IEnumerable<TeamViewModel> Data { get; set; } = new List<TeamViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="teams">Lista de times.</param>
        public TeamListResponse(string message, string code, IEnumerable<TeamViewModel> teams)
        {
            Message = message;
            Code = code;
            Data = teams ?? new List<TeamViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public TeamListResponse()
        {
            Data = new List<TeamViewModel>();
        }
    }
}
