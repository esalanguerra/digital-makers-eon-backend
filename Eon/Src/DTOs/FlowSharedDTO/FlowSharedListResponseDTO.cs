namespace Eon.DTOs.FlowSharedDTO
{
    // DTO para uma coleção de fluxos compartilhados
    public class FlowSharedListResponseDTO
    {
        // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
        public string Message { get; set; }

        // Código de resposta (por exemplo, um código de status ou erro)
        public string Code { get; set; }

        // Lista de fluxos compartilhados encapsulados em FlowSharedViewModelDTO
        public IEnumerable<FlowSharedViewModelDTO> Data { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        public FlowSharedListResponseDTO(string message, string code, IEnumerable<FlowSharedViewModelDTO> flowSharedList)
        {
            Message = message;
            Code = code;
            Data = flowSharedList;
        }

        // Construtor padrão
        public FlowSharedListResponseDTO()
        {
            Data = new List<FlowSharedViewModelDTO>();
        }
    }
}
