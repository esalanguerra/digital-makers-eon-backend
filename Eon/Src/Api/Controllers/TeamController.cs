using Eon.DTOs.TeamDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : ControllerBase, ITeamControllerInterface
    {
        private readonly ITeamServiceInterface _teamService;

        public TeamController(ITeamServiceInterface teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teamListResponse = _teamService.GetAll();
            if (teamListResponse == null || !teamListResponse.Data.Any())
            {
                return NotFound(new TeamListResponseDTO
                {
                    Message = "No teams found.",
                    Code = "404",
                    Data = new List<TeamViewModelDTO>()
                });
            }

            return Ok(teamListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teamResponse = _teamService.GetById(id);

            if (teamResponse == null)
            {
                return NotFound(new SingleTeamResponseDTO
                {
                    Message = "Team not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(teamResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateTeamRequestDTO teamDto)
        {
            if (teamDto == null)
            {
                return BadRequest("Team data is required.");
            }

            var createdTeamResponse = _teamService.Save(teamDto);

            if (createdTeamResponse == null)
            {
                return BadRequest(new SingleTeamResponseDTO
                {
                    Message = "Team could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTeamResponse.Data?.Id },
                createdTeamResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTeamRequestDTO teamDto)
        {
            if (teamDto == null)
            {
                return BadRequest("Team data is required.");
            }

            var existingTeamResponse = _teamService.GetById(id);

            if (existingTeamResponse == null)
            {
                return NotFound(new SingleTeamResponseDTO
                {
                    Message = "Team not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedTeamResponse = _teamService.Update(id, teamDto);
            if (updatedTeamResponse == null)
            {
                return BadRequest(new SingleTeamResponseDTO
                {
                    Message = "Team could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teamResponse = _teamService.GetById(id);

            if (teamResponse == null)
            {
                return NotFound(new SingleTeamResponseDTO
                {
                    Message = "Team not found.",
                    Code = "404",
                    Data = null
                });
            }

            _teamService.Delete(id);
            return NoContent();
        }
    }
}
