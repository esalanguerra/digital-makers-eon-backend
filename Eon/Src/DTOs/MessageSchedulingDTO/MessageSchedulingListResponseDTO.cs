// DTO para uma coleção de mensagens agendadas
using Eon.DTOs.MessageSchedulingDTO;

public class MessageSchedulingListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de mensagens agendadas encapsuladas em MessageSchedulingViewModelDTO
    public IEnumerable<MessageSchedulingViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public MessageSchedulingListResponseDTO(string message, string code, IEnumerable<MessageSchedulingViewModelDTO> messageSchedulings)
    {
        Message = message;
        Code = code;
        Data = messageSchedulings;
    }

    // Construtor padrão
    public MessageSchedulingListResponseDTO()
    {
        Data = new List<MessageSchedulingViewModelDTO>();
    }
}
