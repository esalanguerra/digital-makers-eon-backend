using Eon.DTOs.UserDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase, IUserControllerInterface
    {
        private readonly IUserServiceInterface _userService;

        public UserController(IUserServiceInterface userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Obtém todos os usuários
            var userListResponse = _userService.GetAll();
            if (userListResponse == null || !userListResponse.Data.Any())
            {
                return NotFound(new UserListResponseDTO
                {
                    Message = "No users found.",
                    Code = "404",
                    Data = new List<UserViewModelDTO>()
                });
            }

            return Ok(userListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
                return NotFound(new SingleUserResponseDTO
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(userResponse);
        }

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
                return BadRequest(new SingleUserResponseDTO
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
                return NotFound(new SingleUserResponseDTO
                {
                    Message = "User not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedUserResponse = _userService.Update(id, userDto);
            if (updatedUserResponse == null)
            {
                return BadRequest(new SingleUserResponseDTO
                {
                    Message = "User could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
            {
                return NotFound(new SingleUserResponseDTO
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
