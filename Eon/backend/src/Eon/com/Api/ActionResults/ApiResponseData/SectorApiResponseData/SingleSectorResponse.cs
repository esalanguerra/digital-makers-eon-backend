using Eon.Com.Api.ActionResults.ViewModels.SectorViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.SectorApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação de um único setor.
    /// </summary>
    public class SingleSectorResponse
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
        /// Dados do setor encapsulados em SectorViewModel.
        /// </summary>
        public SectorViewModel Data { get; set; } = new SectorViewModel();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="sector">Dados do setor.</param>
        public SingleSectorResponse(string message, string code, SectorViewModel sector)
        {
            Message = message;
            Code = code;
            Data = sector;
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SingleSectorResponse()
        {
        }
    }
}
