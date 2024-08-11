using System.Collections.Generic;
using Eon.DTOs.TeamDTO;

// DTO para uma coleção de times
public class TeamListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de times encapsulados em TeamViewModelDTO
    public IEnumerable<TeamViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public TeamListResponseDTO(string message, string code, IEnumerable<TeamViewModelDTO> teams)
    {
        Message = message;
        Code = code;
        Data = teams;
    }

    // Construtor padrão
    public TeamListResponseDTO()
    {
        Data = new List<TeamViewModelDTO>();
    }
}
