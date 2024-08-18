using Eon.Com.Api.ActionResults.ApiResponseData.TeamApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.TeamViewModel;
using Eon.Com.Domain.Models.Dto.TeamDto;
using Eon.Com.Interfaces.Factories.TeamFactory;
using Eon.Com.Interfaces.Repositories.TeamRepository;
using Eon.Com.Interfaces.Services.TeamService;

namespace Eon.Com.Api.Mvc.TeamMvc.Service
{
    public class TeamService : ITeamServiceInterface
    {
        private readonly ITeamRepositoryInterface _teamRepository;
        private readonly ITeamFactoryInterface _teamFactory;

        // Construtor que injeta as dependências necessárias
        public TeamService(ITeamRepositoryInterface teamRepository, ITeamFactoryInterface teamFactory)
        {
            _teamRepository = teamRepository;
            _teamFactory = teamFactory;
        }

        /// <summary>
        /// Obtém todas as equipes e retorna uma resposta com uma lista de equipes.
        /// </summary>
        public TeamListResponse GetAll()
        {
            var teams = _teamRepository.GetAll();
            var teamDtos = teams.Select(team => new TeamViewModel(
                team.Id, 
                team.Name, 
                team.Description,
                team.SectorId
            )).ToList(); // Convert to List for better performance in case of large datasets

            return new TeamListResponse("Success", "200", teamDtos);
        }

        /// <summary>
        /// Obtém uma equipe pelo ID e retorna uma resposta com os dados da equipe.
        /// </summary>
        public SingleTeamResponse? GetById(int id)
        {
            var team = _teamRepository.GetById(id);
            if (team == null)
            {
                return new SingleTeamResponse("Team not found", "404", null);
            }

            var teamDto = new TeamViewModel(
                team.Id, 
                team.Name, 
                team.Description,
                team.SectorId
            );

            return new SingleTeamResponse("Success", "200", teamDto);
        }

        /// <summary>
        /// Obtém uma equipe pelo nome e retorna uma resposta com os dados da equipe.
        /// </summary>
        public SingleTeamResponse? GetByName(string name)
        {
            var team = _teamRepository.GetByName(name);
            if (team == null)
            {
                return new SingleTeamResponse("Team not found", "404", null);
            }

            var teamDto = new TeamViewModel(
                team.Id, 
                team.Name, 
                team.Description,
                team.SectorId
            );

            return new SingleTeamResponse("Success", "200", teamDto);
        }

        /// <summary>
        /// Cria uma nova equipe com base nos dados fornecidos e retorna uma resposta com a equipe criada.
        /// </summary>
        public SingleTeamResponse Save(CreateTeamRequestDTO teamDto)
        {
            // Valida os dados da equipe usando TeamFactory
            _teamFactory.ValidateCreateTeamRequest(teamDto);

            // Cria uma nova equipe a partir do DTO
            var team = _teamFactory.CreateTeam(teamDto);

            // Salva a equipe no repositório
            var savedTeam = _teamRepository.Add(team);

            // Cria e retorna a resposta
            var responseDto = new TeamViewModel(
                savedTeam.Id, 
                savedTeam.Name, 
                savedTeam.Description,
                team.SectorId
            );

            return new SingleTeamResponse("Team created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza uma equipe existente com base nos dados fornecidos e retorna uma resposta com a equipe atualizada.
        /// </summary>
        public SingleTeamResponse Update(int id, UpdateTeamRequestDTO teamDto)
        {
            // Valida os dados da equipe usando TeamFactory
            _teamFactory.ValidateUpdateTeamRequest(teamDto);

            // Recupera a equipe existente
            var existingTeam = _teamRepository.GetById(id);
            if (existingTeam == null)
            {
                return new SingleTeamResponse("Team not found", "404", null);
            }

            // Atualiza a equipe com os dados do DTO
            var updatedTeam = _teamFactory.UpdateTeam(existingTeam, teamDto);

            // Salva a equipe atualizada no repositório
            var savedTeam = _teamRepository.Update(updatedTeam);

            // Cria e retorna a resposta
            var responseDto = new TeamViewModel(
                savedTeam.Id, 
                savedTeam.Name, 
                savedTeam.Description,
                savedTeam.SectorId
            );

            return new SingleTeamResponse("Team updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta uma equipe pelo ID e retorna uma resposta com a equipe deletada.
        /// </summary>
        public SingleTeamResponse Delete(int id)
        {
            // Deleta a equipe do repositório
            var deletedTeam = _teamRepository.Delete(id);
            if (deletedTeam == null)
            {
                return new SingleTeamResponse("Team not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new TeamViewModel(
                deletedTeam.Id, 
                deletedTeam.Name, 
                deletedTeam.Description,
                deletedTeam.SectorId
            );

            return new SingleTeamResponse("Team deleted successfully", "200", responseDto);
        }
    }
}
