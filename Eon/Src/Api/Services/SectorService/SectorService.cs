using Eon.Data.Interfaces.IFactories;
using Eon.Data.Interfaces.IRepositories;
using Eon.Data.Interfaces.IServices;
using Eon.DTOs.SectorDTO;
using Eon.Data.Models.Sectors;

namespace Eon.Api.Services.SectorService
{
    public class SectorService : ISectorServiceInterface
    {
        private readonly ISectorRepositoryInterface _sectorRepository;
        private readonly ISectorFactoryInterface _sectorFactory;

        public SectorService(ISectorRepositoryInterface sectorRepository, ISectorFactoryInterface sectorFactory)
        {
            _sectorRepository = sectorRepository;
            _sectorFactory = sectorFactory;
        }

        public SectorListResponseDTO GetAll()
        {
            var sectors = _sectorRepository.GetAll();
            var sectorDtos = sectors.Select(sector => new SectorViewModelDTO(sector.Id, sector.Name, sector.Description));
            return new SectorListResponseDTO("Success", "200", sectorDtos);
        }

        public SingleSectorResponseDTO? GetById(int id)
        {
            var sector = _sectorRepository.GetById(id);
            if (sector == null)
            {
                return new SingleSectorResponseDTO("Sector not found", "404", null);
            }
            var sectorDto = new SectorViewModelDTO(sector.Id, sector.Name, sector.Description);
            return new SingleSectorResponseDTO("Success", "200", sectorDto);
        }

        public SingleSectorResponseDTO Save(CreateSectorRequestDTO sectorDto)
        {
            _sectorFactory.ValidateCreateSectorRequest(sectorDto);
            var sector = _sectorFactory.CreateSector(sectorDto);
            var savedSector = _sectorRepository.Save(sector);
            var responseDto = new SectorViewModelDTO(savedSector.Id, savedSector.Name, savedSector.Description);
            return new SingleSectorResponseDTO("Sector created successfully", "201", responseDto);
        }

        public SingleSectorResponseDTO Update(int id, UpdateSectorRequestDTO sectorDto)
        {
            _sectorFactory.ValidateUpdateSectorRequest(sectorDto);
            var existingSector = _sectorRepository.GetById(id);
            if (existingSector == null)
            {
                return new SingleSectorResponseDTO("Sector not found", "404", null);
            }
            var updatedSector = _sectorFactory.UpdateSector(existingSector, sectorDto);
            var savedSector = _sectorRepository.Update(id, updatedSector);
            var responseDto = new SectorViewModelDTO(savedSector.Id, savedSector.Name, savedSector.Description);
            return new SingleSectorResponseDTO("Sector updated successfully", "200", responseDto);
        }

        public SingleSectorResponseDTO Delete(int id)
        {
            var deletedSector = _sectorRepository.Delete(id);
            if (deletedSector == null)
            {
                return new SingleSectorResponseDTO("Sector not found", "404", null);
            }
            var responseDto = new SectorViewModelDTO(deletedSector.Id, deletedSector.Name, deletedSector.Description);
            return new SingleSectorResponseDTO("Sector deleted successfully", "200", responseDto);
        }
    }
}
