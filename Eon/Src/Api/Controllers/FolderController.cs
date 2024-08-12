using Eon.DTOs.FolderDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/folders")]
    public class FolderController : ControllerBase, IFolderControllerInterface
    {
        private readonly IFolderServiceInterface _folderService;

        public FolderController(IFolderServiceInterface folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var folderListResponse = _folderService.GetAll();
            if (folderListResponse == null || !folderListResponse.Data.Any())
            {
                return NotFound(new FolderListResponseDTO
                {
                    Message = "No folders found.",
                    Code = "404",
                    Data = new List<FolderViewModelDTO>()
                });
            }

            return Ok(folderListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var folderResponse = _folderService.GetById(id);

            if (folderResponse == null)
            {
                return NotFound(new SingleFolderResponseDTO
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(folderResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateFolderRequestDTO folderDto)
        {
            if (folderDto == null)
            {
                return BadRequest("Folder data is required.");
            }

            var createdFolderResponse = _folderService.Save(folderDto);

            if (createdFolderResponse == null)
            {
                return BadRequest(new SingleFolderResponseDTO
                {
                    Message = "Folder could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdFolderResponse.Data?.Id },
                createdFolderResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateFolderRequestDTO folderDto)
        {
            if (folderDto == null)
            {
                return BadRequest("Folder data is required.");
            }

            var existingFolderResponse = _folderService.GetById(id);

            if (existingFolderResponse == null)
            {
                return NotFound(new SingleFolderResponseDTO
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedFolderResponse = _folderService.Update(id, folderDto);
            if (updatedFolderResponse == null)
            {
                return BadRequest(new SingleFolderResponseDTO
                {
                    Message = "Folder could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var folderResponse = _folderService.GetById(id);

            if (folderResponse == null)
            {
                return NotFound(new SingleFolderResponseDTO
                {
                    Message = "Folder not found.",
                    Code = "404",
                    Data = null
                });
            }

            _folderService.Delete(id);
            return NoContent();
        }
    }
}
