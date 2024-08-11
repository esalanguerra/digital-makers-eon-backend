// DTO para uma coleção de usuários
using Eon.DTOs.UserDTO;

public class UserListResponseDTO
{
    // Mensagem de resposta (por exemplo, "Sucesso" ou "Erro")
    public string Message { get; set; }

    // Código de resposta (por exemplo, um código de status ou erro)
    public string Code { get; set; }

    // Lista de usuários encapsulados em UserViewModelDTO
    public IEnumerable<UserViewModelDTO> Data { get; set; }

    // Construtor para inicializar o DTO com valores específicos
    public UserListResponseDTO(string message, string code, IEnumerable<UserViewModelDTO> users)
    {
        Message = message;
        Code = code;
        Data = users;
    }

    // Construtor padrão
    public UserListResponseDTO()
    {
        Data = new List<UserViewModelDTO>();
    }
}
