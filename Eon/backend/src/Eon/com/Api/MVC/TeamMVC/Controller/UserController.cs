using Eon.Com.Api.ActionResults.ApiResponseData.TeamApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.TeamViewModel;
using Eon.Com.Domain.Models.Dto.TeamDto;
using Eon.Com.Interfaces.Controllers.TeamController;
using Eon.Com.Interfaces.Services.TeamService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.TeamMvc.Controller
{
    [ApiController]
    [Route("api/teams")]
    public class TeamController : ControllerBase, ITeamControllerInterface
    {
        private readonly ITeamServiceInterface _teamService;

        // Construtor que injeta o serviço de equipe
        public TeamController(ITeamServiceInterface teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Obtém todas as equipes.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var teamListResponse = _teamService.GetAll();
            if (teamListResponse == null || !teamListResponse.Data.Any())
            {
                return NotFound(new TeamListResponse
                {
                    Message = "No teams found.",
                    Code = "404",
                    Data = new List<TeamViewModel>()
                });
            }

            return Ok(teamListResponse);
        }

        /// <summary>
        /// Obtém uma equipe pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teamResponse = _teamService.GetById(id);

            if (teamResponse == null)
            {
                return NotFound(new SingleTeamResponse
                {
                    Message = "Team not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(teamResponse);
        }

        /// <summary>
        /// Cria uma nova equipe.
        /// </summary>
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
                return BadRequest(new SingleTeamResponse
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

        /// <summary>
        /// Atualiza uma equipe existente.
        /// </summary>
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
                return NotFound(new SingleTeamResponse
                {
                    Message = "Team not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedTeamResponse = _teamService.Update(id, teamDto);
            if (updatedTeamResponse == null)
            {
                return BadRequest(new SingleTeamResponse
                {
                    Message = "Team could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta uma equipe pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teamResponse = _teamService.GetById(id);

            if (teamResponse == null)
            {
                return NotFound(new SingleTeamResponse
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
