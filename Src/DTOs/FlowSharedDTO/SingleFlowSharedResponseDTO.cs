namespace Eon.DTOs.FlowSharedDTO
{
    // DTO para um único fluxo compartilhado
    public class SingleFlowSharedResponseDTO
    {
        // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
        public string Message { get; set; }

        // Código de resposta (por exemplo, um código de status ou erro)
        public string Code { get; set; }

        // Dados do fluxo compartilhado encapsulados em FlowSharedViewModelDTO
        public FlowSharedViewModelDTO Data { get; set; }

        // Construtor para inicializar o DTO com valores específicos
        public SingleFlowSharedResponseDTO(string message, string code, FlowSharedViewModelDTO flowShared)
        {
            Message = message;
            Code = code;
            Data = flowShared;
        }

        // Construtor padrão
        public SingleFlowSharedResponseDTO()
        {
        }
    }
}
