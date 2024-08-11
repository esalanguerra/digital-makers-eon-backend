using Eon.DTOs.UserDTO;

namespace Eon.Data.Interfaces.IServices
{
    public interface IUserServiceInterface
    {
        // Retorna uma coleção de usuários encapsulada em um DTO com mensagem e código
        UserListResponseDTO GetAll();

        // Retorna um usuário único com base no ID encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleUserResponseDTO? GetById(int id);

        // Retorna um usuário único com base no nome encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleUserResponseDTO? GetByName(string name);

        // Retorna um usuário único com base no e-mail encapsulado em um DTO com mensagem e código, ou nulo se não encontrado
        SingleUserResponseDTO? GetByEmail(string email);

        // Cria um novo usuário com base nos dados fornecidos e retorna um DTO com mensagem e código
        SingleUserResponseDTO? Save(CreateUserRequestDTO userDto);

        // Atualiza um usuário existente com base no ID e nos dados fornecidos, retornando um DTO com mensagem e código
        SingleUserResponseDTO? Update(int id, UpdateUserRequestDTO userDto);

        // Deleta um usuário com base no ID e retorna um DTO com mensagem e código, ou nulo se não encontrado
        SingleUserResponseDTO? Delete(int id);
    }
}
