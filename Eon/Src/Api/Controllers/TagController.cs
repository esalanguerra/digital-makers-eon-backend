using Eon.DTOs.TagDTO;
using Eon.Data.Interfaces.IControllers;
using Eon.Data.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Eon.Api.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagController : ControllerBase, ITagControllerInterface
    {
        private readonly ITagServiceInterface _tagService;

        public TagController(ITagServiceInterface tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tagListResponse = _tagService.GetAll();
            if (tagListResponse == null || !tagListResponse.Data.Any())
            {
                return NotFound(new TagListResponseDTO
                {
                    Message = "No tags found.",
                    Code = "404",
                    Data = new List<TagViewModelDTO>()
                });
            }

            return Ok(tagListResponse);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tagResponse = _tagService.GetById(id);

            if (tagResponse == null)
            {
                return NotFound(new SingleTagResponseDTO
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            return Ok(tagResponse);
        }

        [HttpPost]
        public IActionResult Save([FromBody] CreateTagRequestDTO tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Tag data is required.");
            }

            var createdTagResponse = _tagService.Save(tagDto);

            if (createdTagResponse == null)
            {
                return BadRequest(new SingleTagResponseDTO
                {
                    Message = "Tag could not be created.",
                    Code = "400",
                    Data = null
                });
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdTagResponse.Data?.Id },
                createdTagResponse
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateTagRequestDTO tagDto)
        {
            if (tagDto == null)
            {
                return BadRequest("Tag data is required.");
            }

            var existingTagResponse = _tagService.GetById(id);

            if (existingTagResponse == null)
            {
                return NotFound(new SingleTagResponseDTO
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            var updatedTagResponse = _tagService.Update(id, tagDto);
            if (updatedTagResponse == null)
            {
                return BadRequest(new SingleTagResponseDTO
                {
                    Message = "Tag could not be updated.",
                    Code = "400",
                    Data = null
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tagResponse = _tagService.GetById(id);

            if (tagResponse == null)
            {
                return NotFound(new SingleTagResponseDTO
                {
                    Message = "Tag not found.",
                    Code = "404",
                    Data = null
                });
            }

            _tagService.Delete(id);
            return NoContent();
        }
    }
}
