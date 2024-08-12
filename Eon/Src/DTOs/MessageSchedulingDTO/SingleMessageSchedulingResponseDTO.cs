using Eon.DTOs.MessageSchedulingDTO;

// DTO para uma única mensagem agendada
public class SingleMessageSchedulingResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados da mensagem agendada encapsulados em MessageSchedulingViewModelDTO
    public MessageSchedulingViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleMessageSchedulingResponseDTO(string message, string code, MessageSchedulingViewModelDTO messageScheduling)
    {
        Message = message;
        Code = code;
        Data = messageScheduling;
    }

    // Construtor padrão
    public SingleMessageSchedulingResponseDTO()
    {
    }
}
