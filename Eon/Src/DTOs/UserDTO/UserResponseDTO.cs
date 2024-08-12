using Eon.DTOs.UserDTO;

// DTO para um único usuário
public class SingleUserResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Dados do usuário encapsulados em UserViewModelDTO
    public UserViewModelDTO Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public SingleUserResponseDTO(string message, string code, UserViewModelDTO user)
    {
        Message = message;
        Code = code;
        Data = user;
    }

    // Construtor padrão
    public SingleUserResponseDTO()
    {
    }
}
