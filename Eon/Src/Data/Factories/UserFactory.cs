using Eon.DTOs.UserDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Users;

namespace Eon.Data.Factories
{
    public class UserFactory : IUserFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo usuário.
        // Chama o método privado específico para validação do CreateUserRequestDTO.
        public void ValidateCreateUserRequest(CreateUserRequestDTO dto)
        {
            ValidateCreateUser(dto);
        }

        // Valida os dados fornecidos para atualizar um usuário existente.
        // Chama o método privado específico para validação do UpdateUserRequestDTO.
        public void ValidateUpdateUserRequest(UpdateUserRequestDTO dto)
        {
            ValidateUpdateUser(dto);
        }

        // Método privado para validar os dados do CreateUserRequestDTO.
        // Verifica se os dados necessários estão presentes e válidos.
        private void ValidateCreateUser(CreateUserRequestDTO dto)
        {
            // Verifica se o e-mail não está vazio ou nulo.
            if (string.IsNullOrEmpty(dto.Email))
                throw new ArgumentException("Email is required.");

            // Adicione outras validações conforme necessário, como verificar formato de e-mail, etc.
        }

        // Método privado para validar os dados do UpdateUserRequestDTO.
        // Verifica se os dados fornecidos são válidos para atualizar um usuário existente.
        private void ValidateUpdateUser(UpdateUserRequestDTO dto)
        {
            // Verifica se o e-mail não está vazio ou nulo.
            if (string.IsNullOrEmpty(dto.Email))
                throw new ArgumentException("Email is required.");

            // Adicione outras validações conforme necessário, como verificar formato de e-mail, etc.
        }

        // Cria um objeto User a partir do CreateUserRequestDTO.
        // Preenche as propriedades do User com os dados do DTO.
        public User CreateUser(CreateUserRequestDTO dto)
        {
            return new User
            {
                Name = dto.Name,
                Email = dto.Email
                // Adicione outras propriedades conforme necessário.
            };
        }

        // Atualiza um objeto User existente com base no UpdateUserRequestDTO.
        // Preenche as propriedades do User existente com os dados do DTO.
        public User UpdateUser(User existingUser, UpdateUserRequestDTO dto)
        {
            // Atualiza as propriedades do usuário existente com os dados do DTO.
            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            // Atualize outras propriedades conforme necessário.
            return existingUser;
        }
    }
}
