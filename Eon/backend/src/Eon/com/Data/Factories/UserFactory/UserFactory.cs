using Eon.Com.Domain.Models.Dto.UserDto;
using Eon.Com.Domain.Models.Entity.UserEntity;
using Eon.Com.Interfaces.Factories.UserFactory;

namespace Eon.Com.Data.Factories.UserFactory
{
    /// <summary>
    /// Implementação da fábrica para criação e atualização de usuários.
    /// </summary>
    public class UserFactory : IUserFactoryInterface
    {
        /// <summary>
        /// Valida os dados fornecidos para criar um novo usuário.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o usuário.</param>
        public void ValidateCreateUserRequest(CreateUserRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateCreateUser(dto);
        }

        /// <summary>
        /// Valida os dados fornecidos para atualizar um usuário existente.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para atualizar o usuário.</param>
        public void ValidateUpdateUserRequest(UpdateUserRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo
            ValidateUpdateUser(dto);
        }

        /// <summary>
        /// Método privado para validar os dados do CreateUserRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateCreateUser(CreateUserRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Email is required.", nameof(dto.Email)); // Valida que o e-mail não seja nulo ou em branco

            // Adicione outras validações conforme necessário, como formato de e-mail, etc.
        }

        /// <summary>
        /// Método privado para validar os dados do UpdateUserRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para validação.</param>
        private void ValidateUpdateUser(UpdateUserRequestDTO dto)
        {
            // Adicione validações conforme necessário, por exemplo, garantir que pelo menos um campo esteja presente
        }

        /// <summary>
        /// Cria um objeto User a partir do CreateUserRequestDTO.
        /// </summary>
        /// <param name="dto">O DTO contendo os dados para criar o usuário.</param>
        /// <returns>Um objeto User criado a partir do DTO.</returns>
        public User CreateUser(CreateUserRequestDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                AvatarUrl = dto.AvatarUrl,
                PhoneWhatsapp = dto.PhoneWhatsapp,
                Address = dto.Address,
                Notes = dto.Notes
            };
        }

        /// <summary>
        /// Atualiza um objeto User existente com base no UpdateUserRequestDTO.
        /// </summary>
        /// <param name="existingUser">O usuário existente a ser atualizado.</param>
        /// <param name="dto">O DTO contendo os dados de atualização.</param>
        /// <returns>O objeto User atualizado.</returns>
        public User UpdateUser(User existingUser, UpdateUserRequestDTO dto)
        {
            if (existingUser == null) throw new ArgumentNullException(nameof(existingUser)); // Garante que o usuário não seja nulo
            if (dto == null) throw new ArgumentNullException(nameof(dto)); // Garante que o DTO não seja nulo

            // Atualiza as propriedades do usuário com base nos valores não nulos do DTO
            existingUser.Name = string.IsNullOrEmpty(dto.Name) ? existingUser.Name : dto.Name;
            existingUser.Email = string.IsNullOrEmpty(dto.Email) ? existingUser.Email : dto.Email;
            existingUser.AvatarUrl = string.IsNullOrEmpty(dto.AvatarUrl) ? existingUser.AvatarUrl : dto.AvatarUrl;
            existingUser.PhoneWhatsapp = string.IsNullOrEmpty(dto.PhoneWhatsapp) ? existingUser.PhoneWhatsapp : dto.PhoneWhatsapp;
            existingUser.Address = string.IsNullOrEmpty(dto.Address) ? existingUser.Address : dto.Address;
            existingUser.Notes = string.IsNullOrEmpty(dto.Notes) ? existingUser.Notes : dto.Notes;

            return existingUser;
        }
    }
}
