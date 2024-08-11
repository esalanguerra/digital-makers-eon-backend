using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.TeamDTO;

namespace Eon.Api.Services.TeamService
{
    public class TeamService : ITeamServiceInterface
    {
        private readonly ITeamRepositoryInterface _teamRepository;
        private readonly ITeamFactoryInterface _teamFactory;

        public TeamService(ITeamRepositoryInterface teamRepository, ITeamFactoryInterface teamFactory)
        {
            _teamRepository = teamRepository;
            _teamFactory = teamFactory;
        }

        public TeamListResponseDTO GetAll()
        {
            var teams = _teamRepository.GetAll();
            var teamDtos = teams.Select(team => new TeamViewModelDTO(team.Id, team.Name, team.Description));
            return new TeamListResponseDTO("Success", "200", teamDtos);
        }

        public SingleTeamResponseDTO? GetById(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
            {
                return new SingleTeamResponseDTO("Team not found", "404", null);
            }
            var teamDto = new TeamViewModelDTO(team.Id, team.Name, team.Description);
            return new SingleTeamResponseDTO("Success", "200", teamDto);
        }

        public SingleTeamResponseDTO? GetByName(string name)
        {
            var team = _teamRepository.GetByName(name);
            if (team == null)
            {
                return new SingleTeamResponseDTO("Team not found", "404", null);
            }
            var teamDto = new TeamViewModelDTO(team.Id, team.Name, team.Description);
            return new SingleTeamResponseDTO("Success", "200", teamDto);
        }

        public SingleTeamResponseDTO Save(CreateTeamRequestDTO teamDto)
        {
            _teamFactory.ValidateCreateTeamRequest(teamDto);
            var team = _teamFactory.CreateTeam(teamDto);
            var savedTeam = _teamRepository.Save(team);
            var responseDto = new TeamViewModelDTO(savedTeam.Id, savedTeam.Name, savedTeam.Description);
            return new SingleTeamResponseDTO("Team created successfully", "201", responseDto);
        }

        public SingleTeamResponseDTO Update(int id, UpdateTeamRequestDTO teamDto)
        {
            _teamFactory.ValidateUpdateTeamRequest(teamDto);
            var existingTeam = _teamRepository.GetById(id);
            if (existingTeam == null)
            {
                return new SingleTeamResponseDTO("Team not found", "404", null);
            }
            var updatedTeam = _teamFactory.UpdateTeam(existingTeam, teamDto);
            var savedTeam = _teamRepository.Update(id, updatedTeam);
            var responseDto = new TeamViewModelDTO(savedTeam.Id, savedTeam.Name, savedTeam.Description);
            return new SingleTeamResponseDTO("Team updated successfully", "200", responseDto);
        }

        public SingleTeamResponseDTO Delete(int id)
        {
            var deletedTeam = _teamRepository.Delete(id);
            if (deletedTeam == null)
            {
                return new SingleTeamResponseDTO("Team not found", "404", null);
            }
            var responseDto = new TeamViewModelDTO(deletedTeam.Id, deletedTeam.Name, deletedTeam.Description);
            return new SingleTeamResponseDTO("Team deleted successfully", "200", responseDto);
        }
    }
}
