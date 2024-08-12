using System.Collections.Generic;
using Eon.DTOs.TokenDTO;

// DTO para uma coleção de tokens
public class TokenListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de tokens encapsulados em TokenViewModelDTO
    public IEnumerable<TokenViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public TokenListResponseDTO(string message, string code, IEnumerable<TokenViewModelDTO> tokens)
    {
        Message = message;
        Code = code;
        Data = tokens;
    }

    // Construtor padrão
    public TokenListResponseDTO()
    {
        Data = new List<TokenViewModelDTO>();
    }
}
