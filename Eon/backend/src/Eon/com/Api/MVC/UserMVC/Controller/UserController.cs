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

        // Construtor que injeta o serviço de usuário
        public UserController(IUserServiceInterface userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var userListResponse = _userService.GetAll();
            if (userListResponse == null || !userListResponse.Data.Any())
            {
                return NotFound(new UserListResponseDTO
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
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
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
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateUserRequestDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            var createdUserResponse = _userService.Save(userDto);

            if (createdUserResponse == null)
            {
                return BadRequest(new SingleUserResponse
                {
                    Message = "User could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdUserResponse.Data?.Id },
                createdUserResponse
            );
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserRequestDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            var existingUserResponse = _userService.GetById(id);

            if (existingUserResponse == null)
            {
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
                return BadRequest(new SingleUserResponse
                {
                    Message = "User could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um usuário pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
                return NotFound(new SingleUserResponse
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            _userService.Delete(id);
            return NoContent();
        }
    }
}
