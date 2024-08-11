using Eon.DTOs.SectorDTO;
using Eon.Data.Interfaces.IFactories;
using Eon.Data.Models.Sectors;

namespace Eon.Data.Factories
{
    public class SectorFactory : ISectorFactoryInterface
    {
        public void ValidateCreateSectorRequest(CreateSectorRequestDTO dto)
        {
            ValidateCreateSector(dto);
        }

        public void ValidateUpdateSectorRequest(UpdateSectorRequestDTO dto)
        {
            ValidateUpdateSector(dto);
        }

        private void ValidateCreateSector(CreateSectorRequestDTO dto)
        {
            if (dto.Team == null || dto.Team.Length == 0)
                throw new ArgumentException("Team is required.");

            if (string.IsNullOrEmpty(dto.Description))
                throw new ArgumentException("Description is required.");
        }

        private void ValidateUpdateSector(UpdateSectorRequestDTO dto)
        {
            if (dto.Team == null || dto.Team.Length == 0)
                throw new ArgumentException("Team is required.");

            if (string.IsNullOrEmpty(dto.Description))
                throw new ArgumentException("Description is required.");
        }

        public Sector CreateSector(CreateSectorRequestDTO dto)
        {
            return new Sector
            {
                Team = dto.Team,
                Description = dto.Description,
                TeamId = dto.TeamId
            };
        }

        public Sector UpdateSector(Sector existingSector, UpdateSectorRequestDTO dto)
        {
            existingSector.Team = dto.Team;
            existingSector.Description = dto.Description;
            existingSector.TeamId = (int)dto.TeamId;
            return existingSector;
        }
    }
}
