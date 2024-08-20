using Eon.Com.Api.ActionResults.ViewModels.TeamViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.TeamApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de um único time.
    /// </summary>
    public class SingleTeamResponse
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
        /// Dados do time encapsulados em TeamViewModel.
        /// </summary>
        public TeamViewModel Data { get; set; } = new TeamViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="team">Dados do time.</param>
        public SingleTeamResponse(string message, string code, TeamViewModel team)
        {
            Message = message;
            Code = code;
            Data = team;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleTeamResponse()
        {
        }
    }
}
