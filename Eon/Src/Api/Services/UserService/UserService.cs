using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.UserDTO;

namespace Eon.Api.Services.UserService
{
    public class UserService : IUserServiceInterface
    {
        private readonly IUserRepositoryInterface _userRepository;
        private readonly IUserFactoryInterface _userFactory;

        // Construtor que injeta as dependências necessárias
        public UserService(IUserRepositoryInterface userRepository, IUserFactoryInterface userFactory)
        {
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        // Obtém todos os usuários e retorna como UserListResponseDTO
        public UserListResponseDTO GetAll()
        {
            var users = _userRepository.GetAll();
            var userDtos = users.Select(user => new UserViewModelDTO(user.Id, user.Name, user.Email));
            return new UserListResponseDTO("Success", "200", userDtos);
        }

        // Obtém um usuário pelo ID e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return new SingleUserResponseDTO("User not found", "404", null);
            }
            var userDto = new UserViewModelDTO(user.Id, user.Name, user.Email);
            return new SingleUserResponseDTO("Success", "200", userDto);
        }

        // Obtém um usuário pelo nome e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO? GetByName(string name)
        {
            var user = _userRepository.GetByName(name);
            if (user == null)
            {
                return new SingleUserResponseDTO("User not found", "404", null);
            }
            var userDto = new UserViewModelDTO(user.Id, user.Name, user.Email);
            return new SingleUserResponseDTO("Success", "200", userDto);
        }

        // Obtém um usuário pelo e-mail e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO? GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return new SingleUserResponseDTO("User not found", "404", null);
            }
            var userDto = new UserViewModelDTO(user.Id, user.Name, user.Email);
            return new SingleUserResponseDTO("Success", "200", userDto);
        }

        // Salva um novo usuário usando CreateUserRequestDTO e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO Save(CreateUserRequestDTO userDto)
        {
            // Valida os dados do usuário usando UserFactory
            _userFactory.ValidateCreateUserRequest(userDto);

            // Cria um novo usuário a partir do DTO
            var user = _userFactory.CreateUser(userDto);

            // Salva o usuário no repositório
            var savedUser = _userRepository.Save(user);

            // Cria e retorna a resposta
            var responseDto = new UserViewModelDTO(savedUser.Id, savedUser.Name, savedUser.Email);
            return new SingleUserResponseDTO("User created successfully", "201", responseDto);
        }

        // Atualiza um usuário existente com base no UpdateUserRequestDTO e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO Update(int id, UpdateUserRequestDTO userDto)
        {
            // Valida os dados do usuário usando UserFactory
            _userFactory.ValidateUpdateUserRequest(userDto);

            // Recupera o usuário existente
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return new SingleUserResponseDTO("User not found", "404", null);
            }

            // Atualiza o usuário com os dados do DTO
            var updatedUser = _userFactory.UpdateUser(existingUser, userDto);

            // Salva o usuário atualizado no repositório
            var savedUser = _userRepository.Update(id, updatedUser);

            // Cria e retorna a resposta
            var responseDto = new UserViewModelDTO(savedUser.Id, savedUser.Name, savedUser.Email);
            return new SingleUserResponseDTO("User updated successfully", "200", responseDto);
        }

        // Deleta um usuário pelo ID e retorna como SingleUserResponseDTO
        public SingleUserResponseDTO Delete(int id)
        {
            // Deleta o usuário do repositório
            var deletedUser = _userRepository.Delete(id);
            if (deletedUser == null)
            {
                return new SingleUserResponseDTO("User not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new UserViewModelDTO(deletedUser.Id, deletedUser.Name, deletedUser.Email);
            return new SingleUserResponseDTO("User deleted successfully", "200", responseDto);
        }
    }
}
