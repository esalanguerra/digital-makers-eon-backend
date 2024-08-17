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
            if (string.IsNullOrEmpty(dto.Email))
                throw new ArgumentException("Email is required.");

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
            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            existingUser.AvatarUrl = dto.AvatarUrl;
            existingUser.PhoneWhatsapp = dto.PhoneWhatsapp;
            existingUser.Address = dto.Address;
            existingUser.Notes = dto.Notes;

            return existingUser;
        }
    }
}
