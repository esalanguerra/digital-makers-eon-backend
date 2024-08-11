using Eon.DTOs.TagDTO;

// DTO para uma única etiqueta
public class SingleTagResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados da etiqueta encapsulados em TagViewModelDTO
    public TagViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleTagResponseDTO(string message, string code, TagViewModelDTO tag)
    {
        Message = message;
        Code = code;
        Data = tag;
    }

    // Construtor padrão
    public SingleTagResponseDTO()
    {
    }
}
