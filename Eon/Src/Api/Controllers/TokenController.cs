using Eon.DTOs.TokenDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/tokens")]
    public class TokenController : ControllerBase, ITokenControllerInterface
    {
        private readonly ITokenServiceInterface _tokenService;

        public TokenController(ITokenServiceInterface tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tokenListResponse = _tokenService.GetAll();
            if (tokenListResponse == null || !tokenListResponse.Data.Any())
            {
                return NotFound(new TokenListResponseDTO
                {
                    Message = "No tokens found.",
                    Code = "404",
                    Data = new List<TokenViewModelDTO>()
                });
            }

            return Ok(tokenListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tokenResponse = _tokenService.GetById(id);

            if (tokenResponse == null)
            {
                return NotFound(new SingleTokenResponseDTO
                {
                    Message = "Token not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(tokenResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateTokenRequestDTO tokenDto)
        {
            if (tokenDto == null)
            {
                return BadRequest("Token data is required.");
            }

            var createdTokenResponse = _tokenService.Save(tokenDto);

            if (createdTokenResponse == null)
            {
                return BadRequest(new SingleTokenResponseDTO
                {
                    Message = "Token could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTokenResponse.Data?.Id },
                createdTokenResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTokenRequestDTO tokenDto)
        {
            if (tokenDto == null)
            {
                return BadRequest("Token data is required.");
            }

            var existingTokenResponse = _tokenService.GetById(id);

            if (existingTokenResponse == null)
            {
                return NotFound(new SingleTokenResponseDTO
                {
                    Message = "Token not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedTokenResponse = _tokenService.Update(id, tokenDto);
            if (updatedTokenResponse == null)
            {
                return BadRequest(new SingleTokenResponseDTO
                {
                    Message = "Token could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tokenResponse = _tokenService.GetById(id);

            if (tokenResponse == null)
            {
                return NotFound(new SingleTokenResponseDTO
                {
                    Message = "Token not found.",
                    Code = "404",
                    Data = null
                });
            }

            _tokenService.Delete(id);
            return NoContent();
        }
    }
}
