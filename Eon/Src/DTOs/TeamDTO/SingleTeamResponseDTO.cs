using Eon.DTOs.TeamDTO;

// DTO para um único time
public class SingleTeamResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados do time encapsulados em TeamViewModelDTO
    public TeamViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleTeamResponseDTO(string message, string code, TeamViewModelDTO team)
    {
        Message = message;
        Code = code;
        Data = team;
    }

    // Construtor padrão
    public SingleTeamResponseDTO()
    {
    }
}
