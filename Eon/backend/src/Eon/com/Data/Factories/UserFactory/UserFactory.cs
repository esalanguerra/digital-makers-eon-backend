using Eon.Com.Domain.Models.Dto.UserDto;
using Eon.Com.Domain.Models.Entity.UserEntity;
using Eon.Com.Interfaces.Factories.UserFactory;

namespace Eon.Com.Data.Factories.UserFactory
{
    public class UserFactory : IUserFactoryInterface
    {
        // Valida os dados fornecidos para criar um novo usuário.
        public void ValidateCreateUserRequest(CreateUserRequestDTO dto)
        {
            ValidateCreateUser(dto);
        }

        // Valida os dados fornecidos para atualizar um usuário existente.
        public void ValidateUpdateUserRequest(UpdateUserRequestDTO dto)
        {
            ValidateUpdateUser(dto);
        }

        // Método privado para validar os dados do CreateUserRequestDTO.
        private void ValidateCreateUser(CreateUserRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                throw new ArgumentException("Email is required.");

            // Adicione outras validações conforme necessário.
        }

        // Método privado para validar os dados do UpdateUserRequestDTO.
        private void ValidateUpdateUser(UpdateUserRequestDTO dto)
        {
            // Adicione outras validações conforme necessário.
        }

        // Cria um objeto User a partir do CreateUserRequestDTO.
        public User CreateUser(CreateUserRequestDTO dto)
        {
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

        // Atualiza um objeto User existente com base no UpdateUserRequestDTO.
        public User UpdateUser(User existingUser, UpdateUserRequestDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.Name))
                existingUser.Name = dto.Name;

            if (!string.IsNullOrEmpty(dto.Email))
                existingUser.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.AvatarUrl))
                existingUser.AvatarUrl = dto.AvatarUrl;

            if (!string.IsNullOrEmpty(dto.PhoneWhatsapp))
                existingUser.PhoneWhatsapp = dto.PhoneWhatsapp;

            if (!string.IsNullOrEmpty(dto.Address))
                existingUser.Address = dto.Address;

            if (!string.IsNullOrEmpty(dto.Notes))
                existingUser.Notes = dto.Notes;

            return existingUser;
        }
    }
}
