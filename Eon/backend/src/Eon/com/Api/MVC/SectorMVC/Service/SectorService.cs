using Eon.Com.Api.ActionResults.ApiResponseData.SectorApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.SectorViewModel;
using Eon.Com.Domain.Models.Dto.SectorDto;
using Eon.Com.Interfaces.Factories.SectorFactory;
using Eon.Com.Interfaces.Repositories.SectorRepository;
using Eon.Com.Interfaces.Services.SectorService;

namespace Eon.Com.Api.Mvc.SectorMvc.Service
{
    public class SectorService : ISectorServiceInterface
    {
        private readonly ISectorRepositoryInterface _sectorRepository;
        private readonly ISectorFactoryInterface _sectorFactory;

        // Construtor que injeta as dependências necessárias
        public SectorService(ISectorRepositoryInterface sectorRepository, ISectorFactoryInterface sectorFactory)
        {
            _sectorRepository = sectorRepository;
            _sectorFactory = sectorFactory;
        }

        /// <summary>
        /// Obtém todos os setores e retorna uma resposta com uma lista de setores.
        /// </summary>
        public SectorListResponse GetAll()
        {
            var sectors = _sectorRepository.GetAll();
            var sectorDtos = sectors.Select(sector => new SectorViewModel(
                sector.Id, 
                sector.Name, 
                sector.Description, 
                sector.UserBusinessId,
                sector.UserBusiness
            )).ToList(); // Convert to List for better performance in case of large datasets
            
            return new SectorListResponse("Success", "200", sectorDtos);
        }

        /// <summary>
        /// Obtém um setor pelo ID e retorna uma resposta com os dados do setor.
        /// </summary>
        public SingleSectorResponse? GetById(int id)
        {
            var sector = _sectorRepository.GetById(id);
            if (sector == null)
            {
                return new SingleSectorResponse("Sector not found", "404", null);
            }

            var sectorDto = new SectorViewModel(
                sector.Id, 
                sector.Name, 
                sector.Description, 
                sector.UserBusinessId,
                sector.UserBusiness
            );

            return new SingleSectorResponse("Success", "200", sectorDto);
        }

        /// <summary>
        /// Obtém um setor pelo nome e retorna uma resposta com os dados do setor.
        /// </summary>
        public SingleSectorResponse? GetByName(string name)
        {
            var sector = _sectorRepository.GetByName(name);
            if (sector == null)
            {
                return new SingleSectorResponse("Sector not found", "404", null);
            }

            var sectorDto = new SectorViewModel(
                sector.Id, 
                sector.Name, 
                sector.Description, 
                sector.UserBusinessId,
                sector.UserBusiness
            );

            return new SingleSectorResponse("Success", "200", sectorDto);
        }

        /// <summary>
        /// Cria um novo setor com base nos dados fornecidos e retorna uma resposta com o setor criado.
        /// </summary>
        public SingleSectorResponse Save(CreateSectorRequestDTO sectorDto)
        {
            // Valida os dados do setor usando SectorFactory
            _sectorFactory.ValidateCreateSectorRequest(sectorDto);

            // Cria um novo setor a partir do DTO
            var sector = _sectorFactory.CreateSector(sectorDto);

            // Salva o setor no repositório
            var savedSector = _sectorRepository.Add(sector);

            // Cria e retorna a resposta
            var responseDto = new SectorViewModel(
                savedSector.Id, 
                savedSector.Name, 
                savedSector.Description, 
                savedSector.UserBusinessId,
                savedSector.UserBusiness
            );
            
            return new SingleSectorResponse("Sector created successfully", "201", responseDto);
        }

        /// <summary>
        /// Atualiza um setor existente com base nos dados fornecidos e retorna uma resposta com o setor atualizado.
        /// </summary>
        public SingleSectorResponse Update(int id, UpdateSectorRequestDTO sectorDto)
        {
            // Valida os dados do setor usando SectorFactory
            _sectorFactory.ValidateUpdateSectorRequest(sectorDto);

            // Recupera o setor existente
            var existingSector = _sectorRepository.GetById(id);
            if (existingSector == null)
            {
                return new SingleSectorResponse("Sector not found", "404", null);
            }

            // Atualiza o setor com os dados do DTO
            var updatedSector = _sectorFactory.UpdateSector(existingSector, sectorDto);

            // Salva o setor atualizado no repositório
            var savedSector = _sectorRepository.Update(updatedSector);

            // Cria e retorna a resposta
            var responseDto = new SectorViewModel(
                savedSector.Id, 
                savedSector.Name, 
                savedSector.Description, 
                savedSector.UserBusinessId,
                savedSector.UserBusiness
            );
            
            return new SingleSectorResponse("Sector updated successfully", "200", responseDto);
        }

        /// <summary>
        /// Deleta um setor pelo ID e retorna uma resposta com o setor deletado.
        /// </summary>
        public SingleSectorResponse Delete(int id)
        {
            // Deleta o setor do repositório
            var deletedSector = _sectorRepository.Delete(id);
            if (deletedSector == null)
            {
                return new SingleSectorResponse("Sector not found", "404", null);
            }

            // Cria e retorna a resposta
            var responseDto = new SectorViewModel(
                deletedSector.Id, 
                deletedSector.Name, 
                deletedSector.Description, 
                deletedSector.UserBusinessId,
                deletedSector.UserBusiness
            );

            return new SingleSectorResponse("Sector deleted successfully", "200", responseDto);
        }
    }
}
