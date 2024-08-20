using Eon.Com.Api.ActionResults.ViewModels.SectorViewModel;

namespace Eon.Com.Api.ActionResults.ApiResponseData.SectorApiResponseData
{
    /// <summary>
    /// Representa a resposta para uma solicitação que retorna uma lista de setores.
    /// </summary>
    public class SectorListResponse
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
        /// Lista de setores encapsulados em SectorViewModel.
        /// </summary>
        public IEnumerable<SectorViewModel> Data { get; set; } = new List<SectorViewModel>();

        /// <summary>
        /// Construtor para inicializar o DTO com valores específicos.
        /// </summary>
        /// <param name="message">Mensagem de resposta.</param>
        /// <param name="code">Código de resposta.</param>
        /// <param name="sectors">Lista de setores.</param>
        public SectorListResponse(string message, string code, IEnumerable<SectorViewModel> sectors)
        {
            Message = message;
            Code = code;
            Data = sectors ?? new List<SectorViewModel>(); // Evita valores nulos
        }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public SectorListResponse()
        {
            Data = new List<SectorViewModel>();
        }
    }
}
