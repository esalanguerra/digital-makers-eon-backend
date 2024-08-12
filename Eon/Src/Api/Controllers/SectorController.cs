using Eon.DTOs.SectorDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorController : ControllerBase, ISectorControllerInterface
    {
        private readonly ISectorServiceInterface _sectorService;

        public SectorController(ISectorServiceInterface sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var sectorListResponse = _sectorService.GetAll();
            if (sectorListResponse == null || !sectorListResponse.Data.Any())
            {
                return NotFound(new SectorListResponseDTO
                {
                    Message = "No sectors found.",
                    Code = "404",
                    Data = new List<SectorViewModelDTO>()
                });
            }

            return Ok(sectorListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sectorResponse = _sectorService.GetById(id);

            if (sectorResponse == null)
            {
                return NotFound(new SingleSectorResponseDTO
                {
                    Message = "Sector not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(sectorResponse);
        }

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
                return BadRequest(new SingleSectorResponseDTO
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
                return NotFound(new SingleSectorResponseDTO
                {
                    Message = "Sector not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedSectorResponse = _sectorService.Update(id, sectorDto);
            if (updatedSectorResponse == null)
            {
                return BadRequest(new SingleSectorResponseDTO
                {
                    Message = "Sector could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sectorResponse = _sectorService.GetById(id);

            if (sectorResponse == null)
            {
                return NotFound(new SingleSectorResponseDTO
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
