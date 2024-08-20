using Eon.Com.Api.ActionResults.ApiResponseData.UserApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.UserViewModel;
using Eon.Com.Domain.Models.Dto.UserDto;
using Eon.Com.Interfaces.Controllers.UserController;
using Eon.Com.Interfaces.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.UserMvc.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase, IUserControllerInterface
    {
        private readonly IUserServiceInterface _userService;

        // Construtor que injeta o serviço de usuário.
        // Recebe uma instância de IUserServiceInterface que será usada para operações de CRUD.
        public UserController(IUserServiceInterface userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// Retorna uma resposta com uma lista de usuários.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var userListResponse = _userService.GetAll();
            if (userListResponse == null || !userListResponse.Data.Any())
            {
                // Retorna uma resposta 404 se nenhum usuário for encontrado.
                return NotFound(new UserListResponse
                {
                    Message = "No users found.",
                    Code = "404",
                    Data = new List<UserViewModel>()
                });
            }

            return Ok(userListResponse);
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// Retorna uma resposta com os dados do usuário ou uma mensagem de erro se o usuário não for encontrado.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
                // Retorna uma resposta 404 se o usuário não for encontrado.
                return NotFound(new SingleUserResponse
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(userResponse);
        }

        /// <summary>
        /// Cria um novo usuário com base nos dados fornecidos.
        /// Retorna uma resposta com os dados do usuário criado ou uma mensagem de erro se a criação falhar.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateUserRequestDTO userDto)
        {
            if (userDto == null)
            {
                // Retorna uma resposta 400 se os dados do usuário não forem fornecidos.
                return BadRequest("User data is required.");
            }

            var createdUserResponse = _userService.Save(userDto);

            if (createdUserResponse == null)
            {
                // Retorna uma resposta 400 se a criação do usuário falhar.
                return BadRequest(new SingleUserResponse
                {
                    Message = "User could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 201 com a localização do novo usuário.
            return CreatedAtAction(
                nameof(GetById),
                new { id = createdUserResponse.Data?.Id },
                createdUserResponse
            );
        }

        /// <summary>
        /// Atualiza um usuário existente com base nos dados fornecidos.
        /// Retorna uma resposta 204 se a atualização for bem-sucedida ou uma mensagem de erro se a atualização falhar.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserRequestDTO userDto)
        {
            if (userDto == null)
            {
                // Retorna uma resposta 400 se os dados do usuário não forem fornecidos.
                return BadRequest("User data is required.");
            }

            var existingUserResponse = _userService.GetById(id);

            if (existingUserResponse == null)
            {
                // Retorna uma resposta 404 se o usuário não for encontrado.
                return NotFound(new SingleUserResponse
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedUserResponse = _userService.Update(id, userDto);
            if (updatedUserResponse == null)
            {
                // Retorna uma resposta 400 se a atualização falhar.
                return BadRequest(new SingleUserResponse
                {
                    Message = "User could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            // Retorna uma resposta 204 indicando que a atualização foi bem-sucedida.
            return NoContent();
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// Retorna uma resposta 204 se a exclusão for bem-sucedida ou uma mensagem de erro se o usuário não for encontrado.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
                // Retorna uma resposta 404 se o usuário não for encontrado.
                return NotFound(new SingleUserResponse
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            _userService.Delete(id);
            // Retorna uma resposta 204 indicando que a exclusão foi bem-sucedida.
            return NoContent();
        }
    }
}
