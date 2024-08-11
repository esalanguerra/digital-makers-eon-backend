using Eon.DTOs.TokenDTO;

// DTO para um único token
public class SingleTokenResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados do token encapsulados em TokenViewModelDTO
    public TokenViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleTokenResponseDTO(string message, string code, TokenViewModelDTO token)
    {
        Message = message;
        Code = code;
        Data = token;
    }

    // Construtor padrão
    public SingleTokenResponseDTO()
    {
    }
}
