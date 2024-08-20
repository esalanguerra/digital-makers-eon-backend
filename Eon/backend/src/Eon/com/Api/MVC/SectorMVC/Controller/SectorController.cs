using Eon.Com.Api.ActionResults.ApiResponseData.SectorApiResponseData;
using Eon.Com.Api.ActionResults.ViewModels.SectorViewModel;
using Eon.Com.Domain.Models.Dto.SectorDto;
using Eon.Com.Interfaces.Controllers.SectorController;
using Eon.Com.Interfaces.Services.SectorService;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Com.Api.Mvc.SectorMvc.Controller
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorController : ControllerBase, ISectorControllerInterface
    {
        private readonly ISectorServiceInterface _sectorService;

        // Construtor que injeta o serviço de setor
        public SectorController(ISectorServiceInterface sectorService)
        {
            _sectorService = sectorService;
        }

        /// <summary>
        /// Obtém todos os setores.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var sectorListResponse = _sectorService.GetAll();
            if (sectorListResponse == null || !sectorListResponse.Data.Any())
            {
                return NotFound(new SectorListResponse
                {
                    Message = "No sectors found.",
                    Code = "404",
                    Data = new List<SectorViewModel>()
                });
            }

            return Ok(sectorListResponse);
        }

        /// <summary>
        /// Obtém um setor pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sectorResponse = _sectorService.GetById(id);

            if (sectorResponse == null)
            {
                return NotFound(new SingleSectorResponse
                {
                    Message = "Sector not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(sectorResponse);
        }

        /// <summary>
        /// Cria um novo setor.
        /// </summary>
        [HttpPost]
        public IActionResult Save([FromBody] CreateSectorRequestDTO sectorDto)
        {
            if (sectorDto == null)
            {
                return BadRequest("Sector data is required.");
            }

            var createdSectorResponse = _sectorService.Save(sectorDto);

            if (createdSectorResponse == null)
            {
                return BadRequest(new SingleSectorResponse
                {
                    Message = "Sector could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdSectorResponse.Data?.Id },
                createdSectorResponse
            );
        }

        /// <summary>
        /// Atualiza um setor existente.
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSectorRequestDTO sectorDto)
        {
            if (sectorDto == null)
            {
                return BadRequest("Sector data is required.");
            }

            var existingSectorResponse = _sectorService.GetById(id);

            if (existingSectorResponse == null)
            {
                return NotFound(new SingleSectorResponse
                {
                    Message = "Sector not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedSectorResponse = _sectorService.Update(id, sectorDto);
            if (updatedSectorResponse == null)
            {
                return BadRequest(new SingleSectorResponse
                {
                    Message = "Sector could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um setor pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sectorResponse = _sectorService.GetById(id);

            if (sectorResponse == null)
            {
                return NotFound(new SingleSectorResponse
                {
                    Message = "Sector not found.",
                    Code = "404",
                    Data = null
                });
            }

            _sectorService.Delete(id);
            return NoContent();
        }
    }
}
