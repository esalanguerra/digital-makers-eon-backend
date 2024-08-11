using Eon.DTOs.TeamDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Teams;

namespace Eon.Data.Factories
{
    public class TeamFactory : ITeamFactoryInterface
    {
        public void ValidateCreateTeamRequest(CreateTeamRequestDTO dto)
        {
            ValidateCreateTeam(dto);
        }

        public void ValidateUpdateTeamRequest(UpdateTeamRequestDTO dto)
        {
            ValidateUpdateTeam(dto);
        }

        private void ValidateCreateTeam(CreateTeamRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrEmpty(dto.Description))
                throw new ArgumentException("Description is required.");
        }

        private void ValidateUpdateTeam(UpdateTeamRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Name))
                throw new ArgumentException("Name is required.");

            if (string.IsNullOrEmpty(dto.Description))
                throw new ArgumentException("Description is required.");
        }

        public Team CreateTeam(CreateTeamRequestDTO dto)
        {
            return new Team
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public Team UpdateTeam(Team existingTeam, UpdateTeamRequestDTO dto)
        {
            existingTeam.Name = dto.Name;
            existingTeam.Description = dto.Description;
            return existingTeam;
        }
    }
}
