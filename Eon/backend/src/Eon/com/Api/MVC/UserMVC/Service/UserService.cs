using Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;
using Eon.Com.Domain.Models.Dto.UserDto;
using Eon.Com.Interfaces.Factories.UserFactory;
using Eon.Com.Interfaces.Repositories.UserRepository;
using Eon.Com.Interfaces.Services.UserService;

namespace Eon.Com.Api.Mvc.UserMvc.Service
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

        /// <summary>
        /// Obtém todos os usuários e retorna uma resposta com uma lista de usuários.
        /// </summary>
        public UserListResponseDTO GetAll()
        {
            var users = _userRepository.GetAll();
            var userDtos = users.Select(user => new UserViewModel(
                user.Id, 
                user.Name, 
                user.Email, 
                user.PhoneWhatsapp, 
                user.Address, 
                user.AvatarUrl, 
                user.Notes
            )).ToList(); // Convert to List for better performance in case of large datasets
            
            return new UserListResponseDTO("Success", "200", userDtos);
        }

        /// <summary>
        /// Obtém um usuário pelo ID e retorna uma resposta com os dados do usuário.
        /// </summary>
        public SingleUserResponse? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return new SingleUserResponse("User not found", "404", null);
            }

            var userDto = new UserViewModel(
                user.Id, 
                user.Name, 
                user.Email, 
                user.PhoneWhatsapp, 
                user.Address, 
                user.AvatarUrl, 
                user.Notes
            );

            return new SingleUserResponse("Success", "200", userDto);
        }

        /// <summary>
        /// Obtém um usuário pelo nome e retorna uma resposta com os dados do usuário.
        /// </summary>
        public SingleUserResponse? GetByName(string name)
        {
            var user = _userRepository.GetByName(name);
            if (user == null)
            {
                return new SingleUserResponse("User not found", "404", null);
            }

            var userDto = new UserViewModel(
                user.Id, 
                user.Name, 
                user.Email, 
                user.PhoneWhatsapp, 
                user.Address, 
                user.AvatarUrl, 
                user.Notes
            );

            return new SingleUserResponse("Success", "200", userDto);
        }

        /// <summary>
        /// Obtém um usuário pelo e-mail e retorna uma resposta com os dados do usuário.
        /// </summary>
        public SingleUserResponse? GetByEmail(string email)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                return new SingleUserResponse("User not found", "404", null);
            }

            var userDto = new UserViewModel(
                user.Id, 
                user.Name, 
                user.Email, 
                user.PhoneWhatsapp, 
                user.Address, 
                user.AvatarUrl, 
                user.Notes
            );

            return new SingleUserResponse("Success", "200", userDto);
        }

        /// <summary>
        /// Cria um novo usuário com base nos dados fornecidos e retorna uma resposta com o usuário criado.
        /// </summary>
        public SingleUserResponse Save(CreateUserRequestDTO userDto)
        {
            // Valida os dados do usuário usando UserFactory
            _userFactory.ValidateCreateUserRequest(userDto);

            // Cria um novo usuário a partir do DTO
            var user = _userFactory.CreateUser(userDto);

            // Salva o usuário no repositório
            var savedUser = _userRepository.Add(user);

            // Cria e retorna a resposta
            var responseDto = new UserViewModel(
                savedUser.Id, 
                savedUser.Name, 
                savedUser.Email, 
                savedUser.PhoneWhatsapp, 
                savedUser.Address, 
                savedUser.AvatarUrl, 
                savedUser.Notes
            );
            
            return new SingleUserResponse("User created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza um usuário existente com base nos dados fornecidos e retorna uma resposta com o usuário atualizado.
        /// </summary>
        public SingleUserResponse Update(int id, UpdateUserRequestDTO userDto)
        {
            // Valida os dados do usuário usando UserFactory
            _userFactory.ValidateUpdateUserRequest(userDto);

            // Recupera o usuário existente
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                return new SingleUserResponse("User not found", "404", null);
            }

            // Atualiza o usuário com os dados do DTO
            var updatedUser = _userFactory.UpdateUser(existingUser, userDto);

            // Salva o usuário atualizado no repositório
            var savedUser = _userRepository.Update(updatedUser);

            // Cria e retorna a resposta
            var responseDto = new UserViewModel(
                savedUser.Id, 
                savedUser.Name, 
                savedUser.Email, 
                savedUser.PhoneWhatsapp, 
                savedUser.Address, 
                savedUser.AvatarUrl, 
                savedUser.Notes
            );
            
            return new SingleUserResponse("User updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta um usuário pelo ID e retorna uma resposta com o usuário deletado.
        /// </summary>
        public SingleUserResponse Delete(int id)
        {
            // Deleta o usuário do repositório
            var deletedUser = _userRepository.Delete(id);
            if (deletedUser == null)
            {
                return new SingleUserResponse("User not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new UserViewModel(
                deletedUser.Id, 
                deletedUser.Name, 
                deletedUser.Email, 
                deletedUser.PhoneWhatsapp, 
                deletedUser.Address, 
                deletedUser.AvatarUrl, 
                deletedUser.Notes
            );

            return new SingleUserResponse("User deleted successfully", "200", responseDto);
        }
    }
}
