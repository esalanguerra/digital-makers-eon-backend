using Eon.Com.Domain.Models.Dto.UserDto;
using Eon.Com.Domain.Models.Entity.UserEntity;

namespace Eon.Com.Interfaces.Factories.UserFactory
{
    public interface IUserFactoryInterface
    {
        // Valida os dados fornecidos para a criação de um novo usuário.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateCreateUserRequest(CreateUserRequestDTO dto);

        // Valida os dados fornecidos para a atualização de um usuário existente.
        // Lança exceções ou retorna mensagens de erro se os dados não forem válidos.
        void ValidateUpdateUserRequest(UpdateUserRequestDTO dto);

        // Cria um novo objeto User com base nos dados fornecidos no CreateUserRequestDTO.
        // Retorna o objeto User criado.
        User CreateUser(CreateUserRequestDTO dto);

        // Atualiza um objeto User existente com base nos dados fornecidos no UpdateUserRequestDTO.
        // Retorna o objeto User atualizado.
        User UpdateUser(User existingUser, UpdateUserRequestDTO dto);
    }
}
