using Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData;
using Eon.Com.Domain.Models.Dto.UserDto;

namespace Eon.Com.Interfaces.Services.UserService
{
    public interface IUserServiceInterface
    {
        // Retorna uma coleção de usuários encapsulada em um DTO com mensagem e código.
        // O DTO UserListResponseDTO contém a lista de usuários e informações adicionais, como mensagens de status.
        UserListResponseDTO GetAll();

        // Retorna um único usuário com base no ID.
        // O retorno é encapsulado em um DTO SingleUserResponse com mensagem e código de status.
        // Se o usuário não for encontrado, pode retornar nulo.
        SingleUserResponse? GetById(int id);

        // Retorna um único usuário com base no nome.
        // O retorno é encapsulado em um DTO SingleUserResponse com mensagem e código de status.
        // Se o usuário não for encontrado, pode retornar nulo.
        SingleUserResponse? GetByName(string name);

        // Retorna um único usuário com base no e-mail.
        // O retorno é encapsulado em um DTO SingleUserResponse com mensagem e código de status.
        // Se o usuário não for encontrado, pode retornar nulo.
        SingleUserResponse? GetByEmail(string email);

        // Cria um novo usuário com base nos dados fornecidos no DTO CreateUserRequestDTO.
        // Retorna um DTO SingleUserResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleUserResponse? Save(CreateUserRequestDTO userDto);

        // Atualiza um usuário existente com base no ID e nos dados fornecidos no DTO UpdateUserRequestDTO.
        // Retorna um DTO SingleUserResponse com mensagem e código de status, indicando sucesso ou falha.
        SingleUserResponse? Update(int id, UpdateUserRequestDTO userDto);

        // Deleta um usuário com base no ID.
        // Retorna um DTO SingleUserResponse com mensagem e código de status, indicando sucesso ou falha.
        // Se o usuário não for encontrado, pode retornar nulo.
        SingleUserResponse? Delete(int id);
    }
}
